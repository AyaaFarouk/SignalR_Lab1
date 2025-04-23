using Lab1.Hubs;
using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();
            builder.Services.AddDbContext<ITIContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("iticon")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapHub<CourseHub>("/course");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Course}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

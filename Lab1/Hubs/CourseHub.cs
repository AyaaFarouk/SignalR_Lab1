using Lab1.Models;
using Microsoft.AspNetCore.SignalR;

namespace Lab1.Hubs
{
    public class CourseHub : Hub
    {
        public ITIContext _context { get; set; }
        public CourseHub(ITIContext context)
        {
            _context = context;
        }
        public void addcourse(Course course)
        {
            //save in db
            _context.Add(course);
            _context.SaveChanges();

            //send data to all online client
            Clients.All.SendAsync("newcourse", course.Crs_Id, course.Crs_Name, course.Crs_Duration, course.Top_Id);
        }

    }
}

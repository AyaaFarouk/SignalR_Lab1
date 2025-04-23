using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers
{
    public class CourseController : Controller
    {
        public ITIContext _context { get; set; }
        public CourseController(ITIContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        //----------------------------------------
        public IActionResult DisplayCourse()
        {
            return View(_context.Courses.ToList());
        }

    }
}

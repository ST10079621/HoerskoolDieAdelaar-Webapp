using HoerskoolDieAdelaar.Data;
using HoerskoolDieAdelaar.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoerskoolDieAdelaar.Controllers
{
    public class TimeTableController : Controller
    {


        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env; // Add this field
        private readonly HoerskoolDieAdelaarDbContext _context;

        public TimeTableController(ILogger<HomeController> logger, IWebHostEnvironment env, HoerskoolDieAdelaarDbContext context)
        {
            _logger = logger;
            _env = env; // Initialize the environment
            _context = context;
        }




        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult ExamTimeTable1()
        {


          
            var timetables = _context.AcademicDocuments.Where(d => d.Category == "Timetables").ToList();
            


            var model = new AcademicsViewModel
            {
               
                Timetables = timetables,
              
            };

            return View(model);
           
        }



        public IActionResult ClassTimeTable1()
        {

            return View();
        }




    }
}

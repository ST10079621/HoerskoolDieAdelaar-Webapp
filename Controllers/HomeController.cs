using HoerskoolDieAdelaar.Models; 
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc; 
using Microsoft.Extensions.Logging; 
using Microsoft.AspNetCore.Hosting; // Add this using directive
using System.Diagnostics; 
using System.IO;
using HoerskoolDieAdelaar.Data;

namespace HoerskoolDieAdelaar.Controllers 
{ 
    [Authorize] 
    public class HomeController : Controller 
    { 
        private readonly ILogger<HomeController> _logger; 
        private readonly IWebHostEnvironment _env; // Add this field
        private readonly HoerskoolDieAdelaarDbContext _context;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env, HoerskoolDieAdelaarDbContext context) 
        { 
            _logger = logger; 
            _env = env; // Initialize the environment
            _context = context;
        }

       

       


        public IActionResult Index() 
        { 
            return View(); 
        }


       




        public IActionResult Academics()
        {


            var pastPapers = _context.AcademicDocuments.Where(d => d.Category == "Past Papers").ToList();
            var timetables = _context.AcademicDocuments.Where(d => d.Category == "Timetables").ToList();
            var studyGuides = _context.AcademicDocuments.Where(d => d.Category == "Study Guides").ToList();
            var studentReports = _context.AcademicDocuments.Where(d => d.Category == "Student Reports").ToList();

            
            var model = new AcademicsViewModel
            {
                PastPapers = pastPapers,
                Timetables = timetables,
                StudyGuides = studyGuides,
                StudentReports = studentReports
            };

            return View(model);
        }


       



		public FileResult DownloadFile(string fileName)
		{
			// Ensure there's a path separator before the file name
			string path = Path.Combine(_env.ContentRootPath, "Files", fileName);
			if (!System.IO.File.Exists(path))
			{
				// Handle the case where the file does not exist
				return null; // Or return a NotFound result
			}

			byte[] bytes = System.IO.File.ReadAllBytes(path);
			return File(bytes, "application/octet-stream", fileName);
		}




        public IActionResult PastPapers()
        {
            var pastPapers = _context.AcademicDocuments.Where(d => d.Category == "Past Papers").ToList();
            

            var model = new AcademicsViewModel
            {
                PastPapers = pastPapers,
                
            };

            return View(model); 
        }

        public IActionResult StudentReport()
        {
          
            var studentReports = _context.AcademicDocuments.Where(d => d.Category == "Student Reports").ToList();


            var model = new AcademicsViewModel
            {
                
                StudentReports = studentReports
            };

            return View(model);
        }

		public IActionResult StudyGuide()
		{
            
            var studyGuides = _context.AcademicDocuments.Where(d => d.Category == "Study Guides").ToList();
           


            var model = new AcademicsViewModel
            {
               
                StudyGuides = studyGuides,
                
            };

            return View(model);
        }

		public IActionResult Sports() 
        { 
            return View(); 
        } 

        public IActionResult AboutUs() 
        { 
            return View(); 
        } 
    } 
}



using HoerskoolDieAdelaar.Data;
using HoerskoolDieAdelaar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoerskoolDieAdelaar.Controllers
{
    public class AcademicsController : Controller
    {

        private readonly HoerskoolDieAdelaarDbContext _context;

        public AcademicsController(HoerskoolDieAdelaarDbContext context)
        {
            _context = context;
        }




        public IActionResult Academics()
        {
           

            var pastPapers = _context.AcademicDocuments.Where(d => d.Category == "Past Papers").ToList();
            var timetables = _context.AcademicDocuments.Where(d => d.Category == "Timetables").ToList();
            var studyGuides = _context.AcademicDocuments.Where(d => d.Category == "Study Guides").ToList();
            var studentReports = _context.AcademicDocuments.Where(d => d.Category == "Student Reports").ToList();

            Console.WriteLine($"Past Papers Count: {pastPapers.Count}");
            Console.WriteLine($"Timetables Count: {timetables.Count}");
            Console.WriteLine($"Study Guides Count: {studyGuides.Count}");
            Console.WriteLine($"Student Reports Count: {studentReports.Count}");

            var model = new AcademicsViewModel
            {
                PastPapers = pastPapers,
                Timetables = timetables,
                StudyGuides = studyGuides,
                StudentReports = studentReports
            };

            return View(model);
        }


    }
}







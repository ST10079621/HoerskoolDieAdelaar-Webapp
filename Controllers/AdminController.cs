using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HoerskoolDieAdelaar.Models;
using HoerskoolDieAdelaar.Data;
using Microsoft.AspNetCore.Hosting;

namespace HoerskoolDieAdelaar.Controllers
{
    public class AdminController : Controller
    {
        private readonly HoerskoolDieAdelaarDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(HoerskoolDieAdelaarDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }



    

        // View the list of past papers, reports, and guides
        public IActionResult Index1()
        {
            var pastPapers = _context.PastPapers.ToList();
            var timetables = _context.Timetables.ToList();
            var reports = _context.StudentReports.ToList();
            var guides = _context.StudyGuides.ToList();
            var sports = _context.SportsInfo.FirstOrDefault();
            var announcements = _context.Announcements.FirstOrDefault();

            ViewData["PastPapers"] = pastPapers;
            ViewData["Timetables"] = timetables;
            ViewData["Reports"] = reports;
            ViewData["Guides"] = guides;
            ViewData["SportsInfo"] = sports;
            ViewData["Announcements"] = announcements;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocument(IFormFile file, string category)
        {
            if (file != null && file.Length > 0)
            {
                // Set the path where files will be saved based on category
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", category);

                // Create the folder if it doesn't exist
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate a unique file name and get the full file path
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Copy the file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Save file information to the database
                var document = new AcademicDocument
                {
                    FileName = file.FileName,
                    FilePath = "/uploads/" + category + "/" + uniqueFileName,
                    UploadDate = DateTime.Now,
                    Category = category
                };

                _context.AcademicDocuments.Add(document);
                await _context.SaveChangesAsync();

                TempData["Message"] = "File uploaded successfully!";
            }
            else
            {
                TempData["Error"] = "Please select a file to upload.";
            }

            return RedirectToAction("Index1");
        }



        // Post a new past paper
        [HttpPost]
        public IActionResult AddPastPaper(PastPaper pastPaper)
        {
            _context.PastPapers.Add(pastPaper);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete a past paper
        public IActionResult DeletePastPaper(int id)
        {
            var paper = _context.PastPapers.FirstOrDefault(p => p.Id == id);
            if (paper != null)
            {
                _context.PastPapers.Remove(paper);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Update sports information
        [HttpPost]
        public IActionResult UpdateSportsInfo(SportsInfo sportsInfo)
        {
            var sports = _context.SportsInfo.FirstOrDefault();
            if (sports != null)
            {
                sports.Details = sportsInfo.Details;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Update announcement
        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            var announcementToUpdate = _context.Announcements.FirstOrDefault();
            if (announcementToUpdate != null)
            {
                announcementToUpdate.Text = announcement.Text;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Other methods for timetables, reports, study guides, etc., follow the same pattern
    }
}

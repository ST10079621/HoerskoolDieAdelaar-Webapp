using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HoerskoolDieAdelaar.Models;

namespace HoerskoolDieAdelaar.Controllers
{
    public class SportsController : Controller
    {
        private List<Sport> sports = new List<Sport>
        {
            new Sport
            {
                Name = "Soccer",
                Teacher = "Mr. Smith",
                TeacherDetails = "Email: smith@school.com, Phone: 0789634223",
                Info = "Soccer matches are held in Term 1 and Term 2. Practices are on Mondays and Wednesdays.",
                Photos = new List<string> { "soccer1.jpg", "soccer2.jpg" }
            },


           

            new Sport
            {
                Name = "Rugby",
                Teacher = "Mr. Brown",
                TeacherDetails = "Email: brown@school.com, Phone: 0673114998",
                Info = "Rugby matches are held in Term 1 and Term 2. Practices are on Tuesdays and Thursdays.",
                Photos = new List<string> { "rugby1.jfif", "rugby2.png" }
            },
            new Sport
            {
                Name = "cross-country",
                Teacher = "Mr. Buns",
                TeacherDetails = "Email: brown@school.com, Phone: 0724567892",
                Info = "Cross Country events are in Term 1 and Term 4. Practices are on Fridays.",
                Photos = new List<string> { "crosscountry1.jfif", "crosscountry2.jfif" }
            },
            new Sport
            {
                Name = "athletics",
                Teacher = "Mr. Brown",
                TeacherDetails = "Email: brown@school.com, Phone: 123-456-7892",
                Info = "Athletics events are held throughout the year. Practices are on various days.",
                Photos = new List<string> { "facility1.jpg", "facility2.jpg" }
            },
            new Sport
            {
                Name = "netball",
                Teacher = "Ms. Green",
                TeacherDetails = "Email: brown@school.com, Phone: 0823946578",
                Info = "Netball matches are held in Term 3 and Term 4. Practices are on Wednesdays and Fridays.",
                Photos = new List<string> { "netball1.jpg", "netball2.jpeg" }
            },
            
        };

        public IActionResult Index()
        {
            return View(sports);
        }

        public IActionResult Details(string name)
        {
            var sport = sports.FirstOrDefault(s => s.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (sport == null)
            {
                return NotFound();
            }

            return View(sport);
        }
    }
}


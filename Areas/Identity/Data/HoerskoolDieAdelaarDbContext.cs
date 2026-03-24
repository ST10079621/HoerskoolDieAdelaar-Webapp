using HoerskoolDieAdelaar.Areas.Identity.Data;
using HoerskoolDieAdelaar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;


namespace HoerskoolDieAdelaar.Data;

public class HoerskoolDieAdelaarDbContext : IdentityDbContext<HoerskoolDieAdelaarUser>
{
    public HoerskoolDieAdelaarDbContext(DbContextOptions<HoerskoolDieAdelaarDbContext> options)
        : base(options)
    {
    }
    public DbSet<AcademicDocument> AcademicDocuments { get; set; }

    // DbSet for PastPapers
    public DbSet<PastPaper> PastPapers { get; set; }

    // Add similar DbSet for other entities like Timetables, StudyGuides, etc.
    public DbSet<Timetable> Timetables { get; set; }
    public DbSet<StudentReport> StudentReports { get; set; }
    public DbSet<StudyGuide> StudyGuides { get; set; }
    public DbSet<SportsInfo> SportsInfo { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
   
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }


}



  

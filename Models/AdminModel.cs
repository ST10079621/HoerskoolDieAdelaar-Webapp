namespace HoerskoolDieAdelaar.Models
{
    public class PastPaper
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; } // Path to the file
        public DateTime UploadedDate { get; set; }
    }

    public class Timetable
    {
        public int Id { get; set; }               // Unique identifier for the timetable
        public string Title { get; set; }         // Title of the timetable
        public string FilePath { get; set; }      // Path to the file (e.g., PDF)
        public DateTime CreatedDate { get; set; } // Date when the timetable was created
    }

    public class StudentReport
    {
        public int Id { get; set; }                // Unique identifier for the report
        public string StudentName { get; set; }    // Name of the student
        public string Grade { get; set; }          // Grade of the student
        public string ReportFilePath { get; set; } // Path to the report file
        public DateTime ReportDate { get; set; }   // Date of the report
    }

    public class StudyGuide
    {
        public int Id { get; set; }                // Unique identifier for the study guide
        public string Title { get; set; }          // Title of the study guide
        public string FilePath { get; set; }       // Path where the study guide file is stored
        public DateTime UploadedDate { get; set; } // Date when the study guide was uploaded
    }

    public class SportsInfo
    {
        public int Id { get; set; }
        public string Details { get; set; }

        public DateTime UpdatedDate { get; set; }
    }

    public class Announcement
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public DateTime AnnouncementDate { get; set; }
    }




}

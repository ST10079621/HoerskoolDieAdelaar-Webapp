namespace HoerskoolDieAdelaar.Models
{
    public class AcademicDocument
    {

        public int Id { get; set; }  // Primary Key
        public string FileName { get; set; }  // Original file name
        public string FilePath { get; set; }  // Path where the file is saved on the server
        public DateTime UploadDate { get; set; }  // Date of upload
        public string Category { get; set; }


    }
}

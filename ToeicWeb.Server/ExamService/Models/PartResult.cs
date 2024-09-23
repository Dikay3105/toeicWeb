namespace ToeicWeb.Server.ExamService.Models
{
    public class PartResult
    {
        public int Id { get; set; }
        public int TotalCorrect { get; set; }
        public int TotalQuestion { get; set; }
        public int TestID { get; set; }
        public int PartID { get; set; }
    }
}

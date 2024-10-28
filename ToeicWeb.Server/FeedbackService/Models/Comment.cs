namespace ToeicWeb.Server.FeedbackService.Models
{
	public class Comment
	{
		public int UserID { get; set; }
		public int PartID { get; set; }
		public string CommentText { get; set; }
		public DateTime CommentDate { get; set; }
		public string ImgAccount { get; set; }
	}
}

using ToeicWeb.Server.AuthService.Models;

namespace ToeicWeb.Server.AuthService.Data
{
	public class FeedbackDbContext : DbContext
	{
		public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options)
			: base(options)
		{
		}

		public DbSet<Comment> Comments { get; set; }
	}
}
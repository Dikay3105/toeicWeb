using Microsoft.EntityFrameworkCore;
using ToeicWeb.Server.FeedbackService.Models;

namespace ToeicWeb.Server.AuthService.Data
{
	public class FeedbackDbContext : DbContext
	{
		public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options)
			: base(options)
		{
		}

		public DbSet<Comment> Comments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Comment>()
				.HasKey(a => a.UserID);
		}
	}
}
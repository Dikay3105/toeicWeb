using Microsoft.EntityFrameworkCore;
using ToeicWeb.Server.FeedbackService.Data;
using ToeicWeb.Server.FeedbackService.Models;

namespace ToeicWeb.Server.FeedbackService.Services
{
	public class ServiceFeedback
	{
		private readonly FeedbackDbContext _context;

		public ServiceFeedback(UserDbContext context)
		{
			_context = context;
		}

		// Get all users
		public async Task<IEnumerable<Comment>> GetAllCommentAsync()
		{
			return await _context.Comments.ToListAsync();
		}

	}
}

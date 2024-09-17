using Microsoft.EntityFrameworkCore;
using ToeicWeb.Server.ExamService.Data;
using ToeicWeb.Server.ExamService.Models;

namespace ToeicWeb.Server.ExamService.Services
{
    public class TestService
    {
        private readonly ExamDbContext _context;

        public TestService(ExamDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Test>> GetTestsAsync()
        {
            return await _context.Tests.ToListAsync();
        }

        // Add other CRUD operations as needed
    }
}

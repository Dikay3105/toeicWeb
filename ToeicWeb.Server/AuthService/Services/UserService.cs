using Microsoft.EntityFrameworkCore;
using ToeicWeb.Server.AuthService.Data;
using ToeicWeb.Server.AuthService.Models;

namespace ToeicWeb.Server.AuthService.Services
{
    public class UserService
    {
        private readonly UserDbContext _context;

        public UserService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Add methods for CRUD operations as needed
    }
}

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

        // Get all users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Get user by ID
        public async Task<User> FindUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Add a new user
        public async Task<User> AddUserAsync(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        // Delete a user by ID
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

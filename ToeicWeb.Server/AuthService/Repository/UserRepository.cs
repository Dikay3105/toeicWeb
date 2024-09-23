using Microsoft.EntityFrameworkCore;
using ToeicWeb.Server.AuthService.Data;
using ToeicWeb.Server.AuthService.Interfaces;
using ToeicWeb.Server.AuthService.Models;

namespace ToeicWeb.Server.AuthService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }
        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public async Task<User> GetUserById(int id)
        {
            return await (_context.Users.FindAsync(id));
        }
        //public bool DeleteUser(User user)
        //{
        //    _context.Users.Remove(user);
        //    return Save();

        //}
        public bool AddUser(User newUser)
        {
            _context.Users.Add(newUser);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public async Task<List<Role>> GetRolesByUserId(int userId)
        {
            var roles = await (from ur in _context.UserRoles
                               join r in _context.Roles on ur.RoleID equals r.RoleID
                               where ur.UserID == userId
                               select r).ToListAsync();

            return roles;
        }
    }
}

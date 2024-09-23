using ToeicWeb.Server.AuthService.Models;

namespace ToeicWeb.Server.AuthService.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        Task<User> GetUserById(int id);
        //bool DeleteUser(User user);
        Task<List<Role>> GetRolesByUserId(int userId);
        bool AddUser(User newUser);
        bool Save();

    }
}

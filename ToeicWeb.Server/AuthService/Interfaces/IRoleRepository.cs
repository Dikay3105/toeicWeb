using ToeicWeb.Server.AuthService.Models;

namespace ToeicWeb.Server.AuthService.Interfaces
{
    public interface IRoleRepository
    {
        ICollection<Role> GetRoles();
        Task<Role> GetRoleById(int id);
        bool DeleteRole(int id);
        bool AddRole(Role newRole);
        bool Save();
    }
}

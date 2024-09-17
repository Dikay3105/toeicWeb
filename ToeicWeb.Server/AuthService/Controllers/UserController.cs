using Microsoft.AspNetCore.Mvc;
using ToeicWeb.Server.AuthService.Models;
using ToeicWeb.Server.AuthService.Services;

namespace ToeicWeb.Server.AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // Add endpoints for CRUD operations as needed
    }
}

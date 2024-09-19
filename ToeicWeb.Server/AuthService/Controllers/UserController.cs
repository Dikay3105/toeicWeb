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

        // Get all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // Get user by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.FindUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(new
                {
                    EC = -1,  // Error Code
                    DT = ""   // Data (can be an empty string or message)
                }); // Return 404 if user not found
            }

            return Ok(user); // Return the found user
        }

        // Add a new user
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User newUser)
        {
            var createdUser = await _userService.AddUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserID }, createdUser); // Return 201 Created
        }

        // Delete user by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.FindUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(); // Return 404 if user not found
            }

            await _userService.DeleteUserAsync(id);
            return NoContent(); // Return 204 No Content
        }
    }
}

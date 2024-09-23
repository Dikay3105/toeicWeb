namespace ToeicWeb.Server.AuthService.Models
{
    public class LoginModel
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
    }
}

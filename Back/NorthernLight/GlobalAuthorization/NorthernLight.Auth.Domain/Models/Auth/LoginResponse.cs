using NorthernLight.Auth.Domain.Models.User;

namespace NorthernLight.Auth.Domain.Models.Auth
{
    public class LoginResponse
    {
        public string? AccessToken { get; set; }
        public UserDTO?  User { get; set; }
    }
}

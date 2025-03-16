namespace NorthernLight.Auth.Domain.Models.Auth
{
    public class LoginResponse
    {
        public string? AccessToken { get; set; }
        public Guid?  UserId { get; set; }
    }
}

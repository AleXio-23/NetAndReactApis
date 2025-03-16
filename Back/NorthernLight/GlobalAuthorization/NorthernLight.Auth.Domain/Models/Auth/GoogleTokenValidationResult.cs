namespace NorthernLight.Auth.Domain.Models.Auth
{
    public class GoogleTokenValidationResult
    {
        public string? Aud { get; set; }
        public string? Exp { get; set; }
    }
}

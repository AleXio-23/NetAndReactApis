using System.ComponentModel.DataAnnotations;

namespace NorthernLight.Auth.Domain.Models.Auth
{
    public class GoogleLoginDto
    {
        [Required]
        public string GoogleAccessToken { get; set; }
    }
}

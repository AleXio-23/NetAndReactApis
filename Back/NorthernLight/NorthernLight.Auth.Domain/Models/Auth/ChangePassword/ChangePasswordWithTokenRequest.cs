using System.ComponentModel.DataAnnotations;

namespace NorthernLight.Auth.Domain.Models.Auth.ChangePassword
{
    public class ChangePasswordWithTokenRequest
    {
        public string? Token { get; set; }
        [Required]
        [StringLength(244, MinimumLength = 8)]
        public string? Password { get; set; }
        [Required]
        [StringLength(244, MinimumLength = 8)]
        public string? ConfirmPassword { get; set; }
    }
}

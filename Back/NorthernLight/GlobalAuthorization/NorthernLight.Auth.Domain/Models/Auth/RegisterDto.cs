using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace NorthernLight.Auth.Domain.Models.Auth
{
    public class RegisterDto
    {
        [Required] public string Email { get; set; } = default!;

        [Required]
        [StringLength(244, MinimumLength = 8)]
        public string Password { get; set; } = default!;

        [Required]
        [StringLength(244, MinimumLength = 8)]
        public string RepeatPassword { get; set; } = default!;
    }
}
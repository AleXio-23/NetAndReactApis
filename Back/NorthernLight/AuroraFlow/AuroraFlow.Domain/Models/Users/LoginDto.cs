using System.ComponentModel.DataAnnotations;

namespace AuroraFlow.Domain.Models.Users;

public class LoginDto
{
    [Required]
    public string? EmailOrUsername { get; set; }

    [Required]
    public string? Password { get; set; }
}
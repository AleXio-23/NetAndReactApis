namespace AuroraFlow.Domain.Models.Users;

public record LoginResponse
{
    public string? AccessToken { get; set; }
    public UserDto? User { get; set; }
}
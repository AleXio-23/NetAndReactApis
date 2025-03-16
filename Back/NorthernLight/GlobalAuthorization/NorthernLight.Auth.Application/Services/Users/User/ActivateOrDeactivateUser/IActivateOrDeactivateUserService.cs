namespace NorthernLight.Auth.Application.Services.Users.User.ActivateOrDeactivateUser
{
    public interface IActivateOrDeactivateUserService
    {
        Task Activate(Guid userId, CancellationToken cancellationToken);
        Task Deactivate(Guid userId, CancellationToken cancellationToken);
    }
}

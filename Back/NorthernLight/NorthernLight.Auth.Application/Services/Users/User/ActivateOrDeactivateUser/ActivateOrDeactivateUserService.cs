using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Persistence.Repository;

namespace NorthernLight.Auth.Application.Services.Users.User.ActivateOrDeactivateUser
{
    public class ActivateOrDeactivateUserService(IRepository<Persistence.Entities.User> userRepository)
        : IActivateOrDeactivateUserService
    {
        public async Task Activate(Guid userId, CancellationToken cancellationToken)
        {
            var getUser = await userRepository.Where(x => x.Id == userId).FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (getUser is { IsActive: false })
            {
                getUser.IsActive = true;
                await userRepository.Update(getUser, cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task Deactivate(Guid userId, CancellationToken cancellationToken)
        {
            var getUser = await userRepository.Where(x => x.Id == userId).FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (getUser is { IsActive: true })
            {
                getUser.IsActive = false;
                await userRepository.Update(getUser, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
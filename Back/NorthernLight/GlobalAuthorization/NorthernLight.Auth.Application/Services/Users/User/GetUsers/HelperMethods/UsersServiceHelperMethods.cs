using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Domain.Models.User;

namespace NorthernLight.Auth.Application.Services.Users.User.GetUsers.HelperMethods
{
    public static class UsersServiceHelperMethods
    {
        public static async Task<List<UserDTO>> UsersPayloadAsync(IQueryable<Persistence.Entities.User> query,
            CancellationToken cancellationToken)
        {
            return await query.Select(x => new UserDTO()
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email,
                IsActive = x.IsActive,
                UserProfile = x.UserProfile == null
                    ? null
                    : new UserProfileDTO()
                    {
                        Id = x.UserProfile.Id,
                        UserId = x.UserProfile.UserId,
                        Firstname = x.UserProfile.Firstname,
                        Lastname = x.UserProfile.Lastname,
                        PhoneNumber1 = x.UserProfile.PhoneNumber1,
                        PhoneNumber2 = x.UserProfile.PhoneNumber2,
                        BirthDate = x.UserProfile.BirthDate,
                        PersonalNumber = x.UserProfile.PersonalNumber,
                        RegisterDate = x.UserProfile.RegisterDate
                    }
            }).ToListAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
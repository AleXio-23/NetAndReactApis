using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Application.Services.Users.User.GetUser;
using NorthernLight.Auth.Domain.Models.User;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Repository;

namespace NorthernLight.Auth.Application.Services.Users.UserProfile.AddOrUpdateProfile
{
    public class AddOrUpdateProfileService(
        IRepository<Persistence.Entities.UserProfile> userProfileRepository,
        IGetUserService getUserService) : IAddOrUpdateProfileService
    {
        public async Task<ServiceResult<UserDTO>> Execute(UserProfileDTO userProfile,
            CancellationToken cancellationToken)
        {
            var getUser =
                (await getUserService.GetUserByUserId(userProfile.UserId ?? default, cancellationToken)
                    .ConfigureAwait(false)).Data ?? throw new ArgumentException("USER_ON_USERID_NOT_FOUND");

            if (userProfile.Id != null)
            {
                var getUserProfile = await userProfileRepository
                                         .Where(x => x.UserId == userProfile.UserId && x.Id == userProfile.Id)
                                         .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false) ??
                                     throw new ArgumentException("USER_PROFILE_ON_Id_AND_USERID_NOT_FOUND");

                getUserProfile.Firstname = userProfile.Firstname;
                getUserProfile.Lastname = userProfile.Lastname;
                getUserProfile.PhoneNumber1 = userProfile.PhoneNumber1;
                getUserProfile.PhoneNumber2 = userProfile.PhoneNumber2;
                getUserProfile.BirthDate = userProfile.BirthDate;
                getUserProfile.PersonalNumber = userProfile.PersonalNumber;

                await userProfileRepository.Update(getUserProfile, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                var newUserProfile = new Persistence.Entities.UserProfile()
                {
                    UserId = userProfile.UserId,
                    Firstname = userProfile.Firstname,
                    Lastname = userProfile.Lastname,
                    PhoneNumber1 = userProfile.PhoneNumber1,
                    PhoneNumber2 = userProfile.PhoneNumber2,
                    BirthDate = userProfile.BirthDate,
                    PersonalNumber = userProfile.PersonalNumber,
                };

                await userProfileRepository.Add(newUserProfile, cancellationToken).ConfigureAwait(false);
            }

            getUser.UserProfile = userProfile;
            return ServiceResult<UserDTO>
                .SuccessResult(getUser);
        }
    }
}
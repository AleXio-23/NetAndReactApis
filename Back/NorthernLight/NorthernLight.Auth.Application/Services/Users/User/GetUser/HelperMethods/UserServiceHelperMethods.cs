using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Domain.Models.User;

namespace NorthernLight.Auth.Application.Services.Users.User.GetUser.HelperMethods
{
    public static class UserServiceHelperMethods
    {
        public static async Task<UserDTO?> UserPayloadAsync(IQueryable<Persistence.Entities.User> query,
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
                    },
                UserDepartmentAndJobPosition = x.UserJobPositions.OrderByDescending(up => up.StartDate)
                    .ThenByDescending(up => up.Id).Select(up => new UserDepartmentAndJobPosition()
                    {
                        PositionId = up.PositionId,
                        Position = up.Position != null ? up.Position.Name : string.Empty,
                        DepartmentId = up.DepartmentId,
                        Department = up.Department != null ? up.Department.Name : string.Empty
                    }).FirstOrDefault(),
            }).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
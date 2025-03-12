namespace NorthernLight.Auth.Domain.Models.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }


        public UserProfileDTO? UserProfile { get; set; }
        public UserDepartmentAndJobPosition? UserDepartmentAndJobPosition { get; set; }
    }
}

namespace NorthernLight.Auth.Persistence.Entities
{
    public partial class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public byte[] PasswordHash { get; set; } = null!;

        public byte[] PasswordSalt { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool? PasswordExpires { get; set; }

        public DateTime? PasswordExpireDate { get; set; }

        public DateTime? PasswordChangeDate { get; set; }

        public bool? IsActive { get; set; }


        public virtual UserProfile? UserProfile { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public virtual ICollection<DepartmentLeads> DepartmentLeads { get; set; } = new List<DepartmentLeads>();
        public virtual ICollection<UserJobPosition> UserJobPositions { get; set; } = new List<UserJobPosition>();

    }
}

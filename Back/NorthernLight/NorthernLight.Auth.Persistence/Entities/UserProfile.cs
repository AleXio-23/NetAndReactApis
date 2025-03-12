namespace NorthernLight.Auth.Persistence.Entities
{
    public partial class UserProfile
    {
        public int Id { get; set; }

        public Guid? UserId { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? PhoneNumber1 { get; set; }

        public string? PhoneNumber2 { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? PersonalNumber { get; set; }

        public DateTime RegisterDate { get; set; }



        public virtual User? User { get; set; }
    }
}

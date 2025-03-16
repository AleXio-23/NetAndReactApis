namespace NorthernLight.Auth.Domain.Models.User
{
    public class UserDepartmentAndJobPosition
    {
        public int? PositionId { get; set; }
        public string? Position { get; set; }
        public int? DepartmentId { get; set; }
        public string? Department { get; set; }
    }
}

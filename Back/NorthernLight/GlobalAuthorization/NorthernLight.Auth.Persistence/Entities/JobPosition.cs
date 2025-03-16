namespace NorthernLight.Auth.Persistence.Entities
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserJobPosition> UserJobPositions { get; set; } = new List<UserJobPosition>();
    }
}

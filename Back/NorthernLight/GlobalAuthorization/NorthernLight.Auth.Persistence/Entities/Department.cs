namespace NorthernLight.Auth.Persistence.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<DepartmentLeads> DepartmentLeads { get; set; } = new List<DepartmentLeads>();
        public virtual ICollection<UserJobPosition> UserJobPositions { get; set; } = new List<UserJobPosition>();
    }
}

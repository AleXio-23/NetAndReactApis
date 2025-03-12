namespace NorthernLight.Auth.Persistence.Entities
{
    public class DepartmentLeads
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Guid UserId { get; set; }
        public virtual Department? Department { get; set; }
        public virtual User? User { get; set; }
    }
}

namespace AuroraFlow.Persistance.Entities;

public class User
{
    public Guid Id { get; set; }
    public Guid GlobalUserId { get; set; }
    public bool? IsActive { get; set; }


}
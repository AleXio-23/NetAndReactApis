namespace AuroraFlow.Persistance.Entities.Tasks;

public class TaskAssignedUsers
{
    public long  TaskId { get; set; }
    public Guid  UserId { get; set; }
    
    public virtual Task Task { get; set; }
    public virtual User User { get; set; }
}
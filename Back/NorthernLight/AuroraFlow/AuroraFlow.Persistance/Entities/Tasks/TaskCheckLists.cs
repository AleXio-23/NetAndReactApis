namespace AuroraFlow.Persistance.Entities.Tasks;

public class TaskCheckLists
{
    public long Id { get; set; }
    // public long TaskId { get; set; }
    public bool IsChecklistDone { get; set; }
    public Guid? AssignedUserId { get; set; }
    public long? CheckListTextId { get; set; }
    
    public virtual TaskCheckListText? TaskCheckListText { get; set; }
    public virtual User? AssignedUser { get; set; }
}
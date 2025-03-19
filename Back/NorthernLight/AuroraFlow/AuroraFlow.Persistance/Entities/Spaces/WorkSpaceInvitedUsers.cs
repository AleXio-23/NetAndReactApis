namespace AuroraFlow.Persistance.Entities.Spaces;

public class WorkSpaceInvitedUsers
{
    public int WorkspaceId { get; set; }
    public int UserId { get; set; }

    public virtual WorkSpace WorkSpace { get; set; }
    public virtual User User { get; set; }
}
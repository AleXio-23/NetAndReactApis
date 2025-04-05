using AuroraFlow.Persistance.Entities.Spaces;
using AuroraFlow.Persistance.Entities.Tasks;

namespace AuroraFlow.Persistance.Entities;

public class User
{
    public Guid Id { get; set; }
    public Guid GlobalUserId { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<WorkSpaceInvitedUsers> WorkSpaceInvitedUsers { get; set; } =
        new List<WorkSpaceInvitedUsers>();

    public virtual ICollection<TaskAssignedUsers> TaskAssignedUsers { get; set; } =
        new List<TaskAssignedUsers>();
    public virtual ICollection<TaskCheckLists> AssignedTaskCheckLists { get; set; } =
        new List<TaskCheckLists>();
}
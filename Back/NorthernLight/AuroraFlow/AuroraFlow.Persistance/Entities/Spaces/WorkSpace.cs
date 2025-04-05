using AuroraFlow.Persistance.Entities.Spaces.SpaceLists;

namespace AuroraFlow.Persistance.Entities.Spaces;

public class WorkSpace
{
    public int Id { get; set; }
    public string? IconUrl { get; set; }
    public string Title { get; set; }
    public bool IsPrivate { get; set; } = false;


    public virtual ICollection<WorkSpaceInvitedUsers> WorkSpaceInvitedUsers { get; set; } = new List<WorkSpaceInvitedUsers>();
    public virtual ICollection<SpaceList> SpaceLists { get; set; } = new List<SpaceList>();
}
namespace AuroraFlow.Persistance.Entities.Spaces;

/// <summary>
/// სფეისთან დაკავშირებული ლისტი (სადაც თასქები და ა.შ გაერთიანდება)
/// </summary>
public class SpaceList
{
    public int Id { get; set; }
    public int WorkSpaceId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int SortIndex { get; set; }
    public bool IsPrivate { get; set; } = false;

    public virtual WorkSpace WorkSpace { get; set; }
    public virtual ICollection<SpaceListStatuses> SpaceListStatuses { get; set; } = new List<SpaceListStatuses>();
}
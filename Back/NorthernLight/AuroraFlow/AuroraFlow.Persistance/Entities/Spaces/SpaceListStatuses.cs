namespace AuroraFlow.Persistance.Entities.Spaces;

public class SpaceListStatuses
{
    public int Id { get; set; }
    public int SpaceListId { get; set; }
    public string Name { get; set; }
    public string? Color { get; set; }
    public int SortIndex { get; set; }
    
    /// <summary>
    /// Mentions that tasks in this status is COMPLETE 
    /// </summary>
    public bool IsCompletedStatusType { get; set; }
    
    public virtual SpaceList SpaceList { get; set; }
}
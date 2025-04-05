using AuroraFlow.Persistance.Entities.Dictionaries;

namespace AuroraFlow.Persistance.Entities.Spaces.SpaceLists;

/// <summary>
/// სტატუსები რომელშიც უნდა განაწილდეს დავალებები 
/// </summary>
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
    public int StatusTypeId { get; set; }

    public virtual SpaceList? SpaceList { get; set; }
    public virtual TaskStatusType? TaskStatusType { get; set; }
}
using AuroraFlow.Persistance.Entities.Spaces.SpaceLists;

namespace AuroraFlow.Persistance.Entities.Dictionaries;

/// <summary>
/// Not Crud-able records (Default, Complete, Closed)
/// </summary>
public class TaskStatusType
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }

    public virtual ICollection<SpaceListStatuses> SpaceListStatuses { get; set; } = new List<SpaceListStatuses>();
}
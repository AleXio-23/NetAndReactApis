namespace AuroraFlow.Persistance.Entities.Dictionaries;

/// <summary>
/// Using for task priorities (urgent,high, medium, low)
/// </summary>
public class TaskPriority
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Color { get; set; }
    public string Name { get; set; }
}
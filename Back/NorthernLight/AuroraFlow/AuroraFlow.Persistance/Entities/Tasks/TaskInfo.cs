using AuroraFlow.Persistance.Entities.Dictionaries;

namespace AuroraFlow.Persistance.Entities.Tasks;

public class TaskInfo
{
    public long Id { get; set; }
    public long TaskId { get; set; }
    public string? Title { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// 10h 30m shown - saved 12312331
    /// </summary>
    public int? TimeEstimate { get; set; }

    public int? TaskPriorityId { get; set; }

    public virtual TaskPriority? TaskPriority { get; set; }
}
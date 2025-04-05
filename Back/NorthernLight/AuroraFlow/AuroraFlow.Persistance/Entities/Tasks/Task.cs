namespace AuroraFlow.Persistance.Entities.Tasks;


/// <summary>
/// დავალება - მთავარი 
/// </summary>
public class Task
{
    public long Id { get; set; }
    
    public long? ParentTaskId { get; set; }
    /// <summary>
    /// Task Information
    /// </summary>
    public long TaskInfoId { get; set; }
    /// <summary>
    /// Generated Unique Task Code
    /// </summary>
    public string TaskCode { get; set; }

    public virtual TaskInfo? TaskInfo { get; set; }
    public virtual ICollection<TaskTrackedTimes> TaskTrackedTimes { get; set; } = new List<TaskTrackedTimes>();
    public virtual ICollection<TaskAssignedUsers> TaskAssignedUsers { get; set; } = new List<TaskAssignedUsers>();
}
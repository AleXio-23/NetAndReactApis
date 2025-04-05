namespace AuroraFlow.Persistance.Entities.Tasks;

public class TaskTrackedTimes
{
    public long Id { get; set; }
    public long TaskId { get; set; }
    public long? TrackedTime { get; set; }
    public DateTime? TrackingStart { get; set; }
    public DateTime? TrackingEnd { get; set; }
    public Guid TrackUserId { get; set; }
    
    public virtual Task? Task { get; set; }
    public virtual User? TrackUser { get; set; }
}
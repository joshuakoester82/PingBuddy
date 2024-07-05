public class ScheduledJobSaveData
{
    public string JobName { get; set; }
    public DateTime StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public string Status { get; set; }
}
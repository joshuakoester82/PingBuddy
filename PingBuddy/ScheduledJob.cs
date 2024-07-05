public class ScheduledJob
{
    public PingJob Job { get; set; }
    public DateTime StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public string Status { get; set; }

    public ScheduledJob(PingJob job, DateTime startTime, TimeSpan duration, string status)
    {
        Job = job;
        StartTime = startTime;
        Duration = duration;
        Status = status;
    }

    public bool ShouldBeRunning()
    {
        var now = DateTime.Now;
        return now >= StartTime && now < StartTime.Add(Duration);
    }
}
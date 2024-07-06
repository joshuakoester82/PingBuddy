using System.Net.NetworkInformation;

public class ScheduledJob
{
    public PingJob Job { get; }
    public DateTime StartTime { get; }
    public TimeSpan Duration { get; }
    public string Status { get; private set; }
    public bool ResultsExported { get; set; }

    public ScheduledJob(PingJob job, DateTime startTime, TimeSpan duration)
    {
        Job = job;
        StartTime = startTime;
        Duration = duration;
        Status = "Pending";
        ResultsExported = false;

        // Set the scheduled properties of the PingJob
        Job.IsScheduled = true;
        Job.ScheduledStartTime = StartTime;
        Job.Duration = Duration;
    }

    public bool ShouldBeRunning()
    {
        return Job.ShouldBeRunning();
    }

    public void UpdateStatus()
    {
        DateTime now = DateTime.Now;
        if (now < StartTime)
        {
            Status = "Pending";
        }
        else if (now >= StartTime && now < StartTime.Add(Duration))
        {
            Status = "Running";
        }
        else if (now >= StartTime.Add(Duration))
        {
            Status = "Completed";
        }
    }

    public PingReply ExecutePing()
    {
        if (ShouldBeRunning())
        {
            return Job.Ping();
        }
        return null;
    }
}
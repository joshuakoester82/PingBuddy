using System.Net.NetworkInformation;

public class ScheduledJob
{
    public PingJob Job { get; }
    public DateTime StartTime { get; }
    public TimeSpan Duration { get; }
    public string Status { get; private set; }

    public ScheduledJob(PingJob job, DateTime startTime, TimeSpan duration)
    {
        Job = job;
        StartTime = startTime;
        Duration = duration;
        Status = "Pending";

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
        if (DateTime.Now < StartTime)
        {
            Status = "Pending";
        }
        else if (ShouldBeRunning())
        {
            Status = "Running";
        }
        else if (DateTime.Now >= StartTime.Add(Duration))
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
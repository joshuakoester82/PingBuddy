using System.Collections.Generic;

public class Settings
{
    public List<PingJob> PingJobs { get; set; }
    // Add any other global settings here, for example:
    // public int DefaultInterval { get; set; }
    // public bool PlaySoundOnAlert { get; set; }

    public Settings()
    {
        PingJobs = new List<PingJob>();
    }
}
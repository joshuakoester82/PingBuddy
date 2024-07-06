public class Settings
{
    public List<PingJob> PingJobs { get; set; }
    public List<Alert> AlertHistory { get; set; }
    public string EmailSmtpServer { get; set; }
    public int EmailSmtpPort { get; set; }
    public string EmailUsername { get; set; }
    public string EmailPassword { get; set; }
    public string EmailFromAddress { get; set; }
    public string EmailToAddress { get; set; }
    public bool UseEmailNotification { get; set; }
    public string SoundAlertFilePath { get; set; }
    public bool UseSoundAlert { get; set; }
    public int EmailMinuteLimit { get; set; } 
    public string ScheduledJobOutputFolder { get; set; }
    public bool AutoExportScheduledJobs { get; set; }

    public Settings()
    {
        PingJobs = new List<PingJob>();
        EmailSmtpPort = 587; // Default port for TLS
        UseEmailNotification = false;
        UseSoundAlert = false;
        AutoExportScheduledJobs = false;
    }
}
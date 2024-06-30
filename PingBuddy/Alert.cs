public class Alert
{
    public DateTime Timestamp { get; set; }
    public string JobName { get; set; }
    public string Message { get; set; }
    public AlertType Type { get; set; }

    public enum AlertType
    {
        HighLatency,
        PacketLoss,
        ConnectionLost,
        NetworkError,
        HostError
    }

    public Alert(string jobName, string message, AlertType type)
    {
        Timestamp = DateTime.Now;
        JobName = jobName;
        Message = message;
        Type = type;
    }

    public override string ToString()
    {
        return $"[{Timestamp:HH:mm:ss}] {JobName}: {Message}";
    }
}


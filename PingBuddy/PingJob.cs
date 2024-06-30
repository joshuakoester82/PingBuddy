using PingBuddy;
using System.Net.NetworkInformation;

public class PingJob
{
    public string Name { get; set; }
    public string Host { get; set; }
    public int Interval { get; set; } // in milliseconds
    public int Timeout { get; set; } // in milliseconds
    public int BufferSize { get; set; }
    public int LatencyThreshold { get; set; }
    public double PacketLossThreshold { get; set; }
    public int ConsecutiveFailures { get; set; }
    public bool PlaySoundOnAlert { get; set; }
    public bool SendEmailOnAlert { get; set; }
    public int TotalPings { get; private set; }
    public int FailedPings { get; private set; }
    public List<PingResult> PingResults { get; set; } = new List<PingResult>();

    public double ApproximatePacketLoss => TotalPings > 0 ? (double)FailedPings / TotalPings * 100 : 0;

    // New properties for scheduling
    public bool IsScheduled { get; set; }
    public DateTime? ScheduledStartTime { get; set; }
    public TimeSpan Duration { get; set; }

    public PingJob()
    {
        // Default values
        Interval = 1000;
        Timeout = 1000;
        BufferSize = 32;
        LatencyThreshold = 100;
        PacketLossThreshold = 5;
        ConsecutiveFailures = 3;
    }

    public PingReply Ping()
    {
        using (var pinger = new Ping())
        {
            try
            {
                byte[] buffer = new byte[BufferSize];
                new Random().NextBytes(buffer);
                var reply = pinger.Send(Host, Timeout, buffer);
                var result = new PingResult
                {
                    Timestamp = DateTime.Now,
                    Status = reply.Status,
                    Latency = reply.Status == IPStatus.Success ? reply.RoundtripTime : -1
                };
                // Check for alerts
                if (reply.Status != IPStatus.Success)
                {
                    result.AlertType = Alert.AlertType.ConnectionLost;
                    result.AlertMessage = $"Connection lost: {reply.Status}";
                }
                else if (reply.RoundtripTime > LatencyThreshold)
                {
                    result.AlertType = Alert.AlertType.HighLatency;
                    result.AlertMessage = $"High latency: {reply.RoundtripTime}ms";
                }
                PingResults.Add(result);
                return reply;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error pinging {Host}: {e.Message}");

                // Create and add an error PingResult
                var errorResult = new PingResult
                {
                    Timestamp = DateTime.Now,
                    Status = IPStatus.Unknown,
                    Latency = -1,
                    AlertType = Alert.AlertType.ConnectionLost,  // Using existing AlertType
                    AlertMessage = $"Error: {e.Message}"
                };
                PingResults.Add(errorResult);

                // Optionally show a message box (consider removing this in production)
                MessageBox.Show($"Error pinging {Host}: {e.Message} Is the host invalid?", "Ping Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Return a default PingReply object
                return null;
            }
        }
    }

    public void ResetPingStats()
    {
        TotalPings = 0;
        FailedPings = 0;
    }

    public bool ShouldBeRunning()
    {
        if (!IsScheduled)
            return true; // Non-scheduled jobs are always running

        var now = DateTime.Now;
        return now >= ScheduledStartTime && now < ScheduledStartTime.Value.Add(Duration);
    }

    public override string ToString()
    {
        return Name;
    }
}

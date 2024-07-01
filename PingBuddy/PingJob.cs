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
    public bool IsScheduled { get; set; }
    public DateTime? ScheduledStartTime { get; set; }
    public TimeSpan Duration { get; set; }
    private int ConsecutiveFailureCount = 0;

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
                TotalPings++;

                // Check for alerts
                if (reply.Status != IPStatus.Success)
                {
                    FailedPings++;
                    ConsecutiveFailureCount++;
                    result.AlertType = Alert.AlertType.ConnectionLost;
                    result.AlertMessage = $"Connection lost: {reply.Status}";
                    if (ConsecutiveFailureCount >= ConsecutiveFailures)
                    {
                        result.AlertType = Alert.AlertType.ConnectionLost;
                        result.AlertMessage = $"Connection lost for {ConsecutiveFailureCount} consecutive pings";
                    }
                }
                else
                {
                    ConsecutiveFailureCount = 0;
                    if (reply.RoundtripTime > LatencyThreshold)
                    {
                        result.AlertType = Alert.AlertType.HighLatency;
                        result.AlertMessage = $"High latency: {reply.RoundtripTime}ms";
                    }
                }

                // Check for packet loss threshold
                if (ApproximatePacketLoss > PacketLossThreshold)
                {
                    result.AlertType = Alert.AlertType.PacketLoss;
                    result.AlertMessage = $"Packet loss threshold exceeded: {ApproximatePacketLoss:F2}%";
                }

                PingResults.Add(result);

                return reply; // Return the PingReply object
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error pinging {Host}: {e.Message}");
                var errorResult = new PingResult
                {
                    Timestamp = DateTime.Now,
                    Status = IPStatus.Unknown,
                    Latency = -1,
                    AlertType = Alert.AlertType.NetworkError,
                    AlertMessage = $"Error: {e.Message}"
                };
                PingResults.Add(errorResult);
                TotalPings++;
                FailedPings++;
                ConsecutiveFailureCount++;
                return null; // Return null in case of an exception
            }
        }
    }

    public void ResetPingStats()
    {
        TotalPings = 0;
        FailedPings = 0;
        ConsecutiveFailures = 0;
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

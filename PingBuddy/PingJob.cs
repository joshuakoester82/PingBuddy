using System;
using System.Net.NetworkInformation;

namespace PingBuddy
{
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
                byte[] buffer = new byte[BufferSize];
                new Random().NextBytes(buffer);
                return pinger.Send(Host, Timeout, buffer);
            }
        }
        public override string ToString()
        {
            return $"{Name} ({Host})";
        }
    }
}
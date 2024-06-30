using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PingBuddy
{
    public class PingResult
    {
        public DateTime Timestamp { get; set; }
        public IPStatus Status { get; set; }
        public long Latency { get; set; }
        public Alert.AlertType? AlertType { get; set; }
        public string AlertMessage { get; set; }
    }
}


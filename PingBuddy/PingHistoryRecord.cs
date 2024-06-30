using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace PingBuddy
{
    public class PingHistoryRecord
    {
        [Name("Timestamp")]
        public DateTime Timestamp { get; set; }

        [Name("Job Name")]
        public string JobName { get; set; }

        [Name("Host")]
        public string Host { get; set; }

        [Name("Status")]
        public string Status { get; set; }

        [Name("Latency (ms)")]
        public long Latency { get; set; }

        [Name("Alert Type")]
        public string AlertType { get; set; }

        [Name("Alert Message")]
        public string AlertMessage { get; set; }
    }
}
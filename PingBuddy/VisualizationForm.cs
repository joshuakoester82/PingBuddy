using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PingBuddy
{
    public partial class VisualizationForm : Form
    {
        private List<PingJob> pingJobs;

        public VisualizationForm()
        {
            InitializeComponent();
            SetupEventHandlers();
            InitializeDatePickers();
        }

        private void SetupEventHandlers()
        {
            updateButton.Click += UpdateButton_Click;
            latencyCheckBox.CheckedChanged += UpdateChart;
            packetLossCheckBox.CheckedChanged += UpdateChart;
            exportDataButton.Click += ExportDataButton_Click;
        }

        private void InitializeDatePickers()
        {
            startDatePicker.Value = DateTime.Now.AddDays(-7);
            endDatePicker.Value = DateTime.Now;
        }

        public void PopulateJobList(List<PingJob> jobs)
        {
            pingJobs = jobs;
            jobListBox.Items.Clear();
            jobListBox.Items.AddRange(jobs.ToArray());
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateChart(sender, e);
        }

        private void UpdateChart(object sender, EventArgs e)
        {
            pingChart.Series.Clear();

            foreach (PingJob job in jobListBox.SelectedItems)
            {
                if (latencyCheckBox.Checked)
                {
                    AddLatencySeries(job);
                }

                if (packetLossCheckBox.Checked)
                {
                    AddPacketLossSeries(job);
                }
            }

            ConfigureChartAreas();
        }

        private void AddLatencySeries(PingJob job)
        {
            Series latencySeries = new Series(job.Name + " Latency")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                Color = GetRandomColor()
            };

            var filteredResults = job.PingResults
                .Where(r => r.Timestamp >= startDatePicker.Value && r.Timestamp <= endDatePicker.Value)
                .Where(r => r.Status == System.Net.NetworkInformation.IPStatus.Success);

            foreach (var result in filteredResults)
            {
                latencySeries.Points.AddXY(result.Timestamp, result.Latency);
            }

            pingChart.Series.Add(latencySeries);
        }

        private void AddPacketLossSeries(PingJob job)
        {
            Series packetLossSeries = new Series(job.Name + " Packet Loss")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                Color = GetRandomColor(),
                YAxisType = AxisType.Secondary
            };

            var groupedResults = job.PingResults
                .Where(r => r.Timestamp >= startDatePicker.Value && r.Timestamp <= endDatePicker.Value)
                .GroupBy(r => r.Timestamp.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    PacketLoss = (double)g.Count(r => r.Status != System.Net.NetworkInformation.IPStatus.Success) / g.Count() * 100
                });

            foreach (var result in groupedResults)
            {
                packetLossSeries.Points.AddXY(result.Date, result.PacketLoss);
            }

            pingChart.Series.Add(packetLossSeries);
        }

        private void ConfigureChartAreas()
        {
            pingChart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy";
            pingChart.ChartAreas[0].AxisX.Title = "Date";
            pingChart.ChartAreas[0].AxisY.Title = "Latency (ms)";
            pingChart.ChartAreas[0].AxisY2.Title = "Packet Loss (%)";

            pingChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
        }

        private Color GetRandomColor()
        {
            Random random = new Random();
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private void ExportDataButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Export Ping Data"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataToCsv(saveFileDialog.FileName);
            }
        }

        private void ExportDataToCsv(string fileName)
        {
            using (var writer = new System.IO.StreamWriter(fileName))
            {
                writer.WriteLine("Timestamp,Job Name,Latency,Status");

                foreach (PingJob job in jobListBox.SelectedItems)
                {
                    var filteredResults = job.PingResults
                        .Where(r => r.Timestamp >= startDatePicker.Value && r.Timestamp <= endDatePicker.Value);

                    foreach (var result in filteredResults)
                    {
                        writer.WriteLine($"{result.Timestamp},{job.Name},{result.Latency},{result.Status}");
                    }
                }
            }

            MessageBox.Show("Data exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
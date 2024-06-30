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
        private List<PingJob> jobs;

        public VisualizationForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Set default date range (e.g., last 24 hours)
            endDatePicker.Value = DateTime.Now;
            startDatePicker.Value = DateTime.Now.AddHours(-24);

            // Wire up event handlers
            updateButton.Click += UpdateButton_Click;
            exportDataButton.Click += ExportDataButton_Click;
            latencyCheckBox.CheckedChanged += VisualizationOption_Changed;
            packetLossCheckBox.CheckedChanged += VisualizationOption_Changed;

            // Initialize the chart
            InitializeChart();
        }

        private void InitializeChart()
        {
            pingChart.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd HH:mm";
            pingChart.ChartAreas[0].AxisX.Title = "Time";
            pingChart.ChartAreas[0].AxisY.Title = "Latency (ms)";

            // Enable zooming and scrolling
            pingChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            pingChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            pingChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            pingChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            pingChart.ChartAreas[0].CursorY.IsUserEnabled = true;
            pingChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            pingChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            pingChart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            // Add a legend
            pingChart.Legends[0].Docking = Docking.Top;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void UpdateChart()
        {
            pingChart.Series.Clear();

            foreach (PingJob job in jobListBox.SelectedItems.Cast<PingJob>())
            {
                Series latencySeries = new Series(job.Name + " Latency")
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.DateTime
                };

                Series alertSeries = new Series(job.Name + " Alerts")
                {
                    ChartType = SeriesChartType.Point,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 10,
                    MarkerColor = Color.Red,
                    XValueType = ChartValueType.DateTime
                };

                foreach (var result in job.PingResults)
                {
                    if (result.Timestamp >= startDatePicker.Value && result.Timestamp <= endDatePicker.Value)
                    {
                        // Only add points for successful pings
                        if (result.Status == System.Net.NetworkInformation.IPStatus.Success)
                        {
                            latencySeries.Points.AddXY(result.Timestamp, result.Latency);

                            // Add alert point only if there's an actual alert
                            if (result.AlertType.HasValue)
                            {
                                int alertPointIndex = alertSeries.Points.AddXY(result.Timestamp, result.Latency);
                                DataPoint alertPoint = alertSeries.Points[alertPointIndex];
                                alertPoint.ToolTip = $"{result.AlertType}: {result.AlertMessage}";
                            }
                        }
                    }
                }

                pingChart.Series.Add(latencySeries);
                pingChart.Series.Add(alertSeries);
            }

            // Adjust X axis range to show only the selected date range
            if (pingChart.Series.Any() && pingChart.Series[0].Points.Any())
            {
                var allPoints = pingChart.Series.SelectMany(s => s.Points).ToList();
                var minDate = allPoints.Min(p => DateTime.FromOADate(p.XValue));
                var maxDate = allPoints.Max(p => DateTime.FromOADate(p.XValue));

                pingChart.ChartAreas[0].AxisX.Minimum = minDate.ToOADate();
                pingChart.ChartAreas[0].AxisX.Maximum = maxDate.ToOADate();
            }
            else
            {
                // If no data, set to selected date range
                pingChart.ChartAreas[0].AxisX.Minimum = startDatePicker.Value.ToOADate();
                pingChart.ChartAreas[0].AxisX.Maximum = endDatePicker.Value.ToOADate();
            }

            // Adjust Y axis to fit the data
            if (pingChart.Series.Any() && pingChart.Series[0].Points.Any())
            {
                var allLatencies = pingChart.Series
                    .Where(s => s.Name.EndsWith("Latency"))
                    .SelectMany(s => s.Points.Select(p => p.YValues[0]))
                    .ToList();

                pingChart.ChartAreas[0].AxisY.Minimum = Math.Max(0, allLatencies.Min() - 5);
                pingChart.ChartAreas[0].AxisY.Maximum = allLatencies.Max() + 5;
            }

            // Ensure proper time formatting
            pingChart.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd HH:mm:ss";
            pingChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            pingChart.ChartAreas[0].AxisX.Interval = 5; // Adjust as needed

            // Reset zoom to show full date range
            pingChart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            pingChart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
        }

        private void ExportDataButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement data export logic
            MessageBox.Show("Data export not yet implemented.");
        }

        private void VisualizationOption_Changed(object sender, EventArgs e)
        {
            UpdateChart();
        }

        public void PopulateJobList(List<PingJob> jobs)
        {
            this.jobs = jobs;
            jobListBox.Items.Clear();
            foreach (var job in jobs)
            {
                jobListBox.Items.Add(job);
            }
        }
    }
}
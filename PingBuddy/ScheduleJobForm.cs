using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PingBuddy
{
    public partial class ScheduleJobForm : Form
    {
        private List<PingJob> availableJobs;
        private List<ScheduledJob> scheduledJobs;

        public ScheduleJobForm(List<PingJob> jobs)
        {
            InitializeComponent();
            availableJobs = jobs;
            scheduledJobs = new List<ScheduledJob>();
            PopulateAvailableJobs();

            // Wire up the Schedule button click event
            scheduleButton.Click += ScheduleButton_Click;
        }

        private void PopulateAvailableJobs()
        {
            availableJobsListView.Items.Clear();
            foreach (var job in availableJobs)
            {
                ListViewItem item = new ListViewItem(job.Name);
                item.SubItems.Add(job.Host);
                item.Tag = job;
                availableJobsListView.Items.Add(item);
            }
        }

        private void ScheduleButton_Click(object sender, EventArgs e)
        {
            if (availableJobsListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a job to schedule.", "No Job Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PingJob selectedJob = (PingJob)availableJobsListView.SelectedItems[0].Tag;
            DateTime startTime = startDateTimePicker.Value;
            TimeSpan duration = TimeSpan.FromMinutes((double)durationNumericUpDown.Value);

            ScheduledJob newScheduledJob = new ScheduledJob
            {
                Job = selectedJob,
                StartTime = startTime,
                Duration = duration,
                Status = "Pending"
            };

            scheduledJobs.Add(newScheduledJob);
            UpdateScheduledJobsListView();
        }

        private void UpdateScheduledJobsListView()
        {
            scheduledJobsListView.Items.Clear();
            foreach (var scheduledJob in scheduledJobs)
            {
                ListViewItem item = new ListViewItem(scheduledJob.Job.Name);
                item.SubItems.Add(scheduledJob.StartTime.ToString("g"));
                item.SubItems.Add(scheduledJob.Duration.TotalMinutes.ToString() + " min");
                item.SubItems.Add(scheduledJob.Status);
                item.Tag = scheduledJob;
                scheduledJobsListView.Items.Add(item);
            }
        }
    }

    public class ScheduledJob
    {
        public PingJob Job { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PingBuddy
{
    public partial class ScheduleJobForm : Form
    {
        public List<PingJob> ScheduledJobs { get; private set; }

        public ScheduleJobForm(List<PingJob> existingJobs)
        {
            InitializeComponent();
            PopulateJobList(existingJobs);
        }

        private void PopulateJobList(List<PingJob> jobs)
        {
            jobListBox.Items.AddRange(jobs.ToArray());
        }

        private void ScheduleButton_Click(object sender, EventArgs e)
        {
            ScheduledJobs = new List<PingJob>();
            foreach (PingJob selectedJob in jobListBox.SelectedItems)
            {
                var scheduledJob = new PingJob
                {
                    Name = selectedJob.Name,
                    Host = selectedJob.Host,
                    Interval = selectedJob.Interval,
                    Timeout = selectedJob.Timeout,
                    BufferSize = selectedJob.BufferSize,
                    LatencyThreshold = selectedJob.LatencyThreshold,
                    PacketLossThreshold = selectedJob.PacketLossThreshold,
                    ConsecutiveFailures = selectedJob.ConsecutiveFailures,
                    PlaySoundOnAlert = selectedJob.PlaySoundOnAlert,
                    SendEmailOnAlert = selectedJob.SendEmailOnAlert,
                    IsScheduled = true,
                    ScheduledStartTime = startDateTimePicker.Value,
                    Duration = TimeSpan.FromMinutes((double)durationNumericUpDown.Value)
                };
                ScheduledJobs.Add(scheduledJob);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
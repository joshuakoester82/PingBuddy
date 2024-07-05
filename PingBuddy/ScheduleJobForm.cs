using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PingBuddy
{
    public partial class ScheduleJobForm : Form
    {
        private List<PingJob> availableJobs;
        private List<ScheduledJob> scheduledJobs;

        public ScheduleJobForm(List<PingJob> jobs, List<ScheduledJob> existingScheduledJobs)
        {
            InitializeComponent();
            availableJobs = jobs;
            scheduledJobs = existingScheduledJobs ?? new List<ScheduledJob>();

            PopulateAvailableJobs();
            UpdateScheduledJobsListView();

            // Wire up button click events
            scheduleButton.Click += ScheduleButton_Click;
            removeScheduledJobButton.Click += RemoveScheduledJobButton_Click;
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            selectOutputFolderButton.Click += SelectOutputFolderButton_Click;
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
        private void SelectOutputFolderButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select Output Folder for Scheduled Job Results";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    outputFolderTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
        private void ScheduleButton_Click(object sender, EventArgs e)
        {
            if (availableJobsListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a job to schedule.", "No Job Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(outputFolderTextBox.Text))
            {
                MessageBox.Show("Please select an output folder.", "No Output Folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PingJob selectedJob = (PingJob)availableJobsListView.SelectedItems[0].Tag;
            DateTime startTime = startDateTimePicker.Value;
            TimeSpan duration = TimeSpan.FromMinutes((double)durationNumericUpDown.Value);

            ScheduledJob newScheduledJob = new ScheduledJob(
                selectedJob,
                startTime,
                duration,
                "Pending",
                outputFolderTextBox.Text
            );

            scheduledJobs.Add(newScheduledJob);
            UpdateScheduledJobsListView();
        }
        private void RemoveScheduledJobButton_Click(object sender, EventArgs e)
        {
            if (scheduledJobsListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a scheduled job to remove.", "No Job Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ScheduledJob selectedJob = (ScheduledJob)scheduledJobsListView.SelectedItems[0].Tag;
            scheduledJobs.Remove(selectedJob);
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
                item.SubItems.Add(scheduledJob.OutputFolder);
                item.Tag = scheduledJob;
                scheduledJobsListView.Items.Add(item);
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(outputFolderTextBox.Text))
            {
                MessageBox.Show("Please select an output folder.", "Output Folder Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Here we're just setting the DialogResult. The actual saving will be done in MainForm.
            this.DialogResult = DialogResult.OK;
        }
        public List<ScheduledJob> GetScheduledJobs()
        {
            return scheduledJobs;
        }
    }
}

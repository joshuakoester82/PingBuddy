using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PingBuddy
{
    public partial class ScheduleJobForm : Form
    {
        private List<PingJob> availableJobs;
        private List<ScheduledJob> scheduledJobs;
        private string outputFolder;
        private Settings appSettings;

        public ScheduleJobForm(List<PingJob> jobs, List<ScheduledJob> existingScheduledJobs, Settings settings)
        {
            InitializeComponent();
            availableJobs = jobs;
            scheduledJobs = new List<ScheduledJob>(existingScheduledJobs ?? new List<ScheduledJob>());
            appSettings = settings;
            outputFolder = settings.ScheduledJobOutputFolder;

            PopulateAvailableJobs();
            UpdateScheduledJobsListView();
            outputFolderTextBox.Text = outputFolder;
            autoExportCheckBox.Checked = appSettings.AutoExportScheduledJobs;

            // Wire up button click events
            scheduleButton.Click += ScheduleButton_Click;
            removeScheduledJobButton.Click += RemoveScheduledJobButton_Click;
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += CancelButton_Click;
            selectOutputFolderButton.Click += SelectOutputFolderButton_Click;
            autoExportCheckBox.CheckedChanged += AutoExportCheckBox_CheckedChanged;
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
        public void UpdateJobStatus(ScheduledJob job)
        {
            if (IsHandleCreated)
            {
                BeginInvoke(new Action(() => UpdateJobStatusInternal(job)));
            }
            else
            {
                HandleCreated += (sender, args) => UpdateJobStatusInternal(job);
            }
        }
        private void UpdateJobStatusInternal(ScheduledJob job)
        {
            foreach (ListViewItem item in scheduledJobsListView.Items)
            {
                if (item.Tag is ScheduledJob scheduledJob && scheduledJob == job)
                {
                    item.SubItems[3].Text = job.Status;
                    break;
                }
            }
        }

        private void SelectOutputFolderButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select Output Folder for Scheduled Job Results";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    outputFolder = folderBrowserDialog.SelectedPath;
                    outputFolderTextBox.Text = outputFolder;
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

            PingJob selectedJob = (PingJob)availableJobsListView.SelectedItems[0].Tag;
            DateTime startTime = startDateTimePicker.Value;
            TimeSpan duration = TimeSpan.FromMinutes((double)durationNumericUpDown.Value);

            ScheduledJob newScheduledJob = new ScheduledJob(
            selectedJob,
            startTime,
            duration,
            autoExportCheckBox.Checked
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
                AddScheduledJobToListView(scheduledJob);
            }
        }
        private void AddScheduledJobToListView(ScheduledJob scheduledJob)
        {
            ListViewItem item = new ListViewItem(scheduledJob.Job.Name);
            item.SubItems.Add(scheduledJob.StartTime.ToString("g"));
            item.SubItems.Add(scheduledJob.Duration.TotalMinutes.ToString() + " min");
            item.SubItems.Add(scheduledJob.Status);
            item.Tag = scheduledJob;
            scheduledJobsListView.Items.Add(item);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(outputFolderTextBox.Text))
            {
                MessageBox.Show("Please select an output folder.", "Output Folder Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            appSettings.ScheduledJobOutputFolder = outputFolderTextBox.Text;
            this.DialogResult = DialogResult.OK;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Discard any changes and close the form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void AutoExportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            appSettings.AutoExportScheduledJobs = autoExportCheckBox.Checked;
        }
        public List<ScheduledJob> GetScheduledJobs()
        {
            return new List<ScheduledJob>(scheduledJobs);
        }
        public string GetOutputFolder()
        {
            return outputFolder;
        }

        private void scheduledJobsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

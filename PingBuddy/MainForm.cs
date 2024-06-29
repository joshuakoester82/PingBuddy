using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Linq;

namespace PingBuddy
{
    public partial class MainForm : Form
    {
        private List<PingJob> pingJobs = new List<PingJob>();
        private BackgroundWorker pingWorker;
        private bool isRunning = false;

        public MainForm()
        {
            InitializeComponent();
            SetupCustomControls();
            SetupPingWorker();
        }

        private void SetupCustomControls()
        {
            addJobButton.Click += AddJobButton_Click;
            editJobButton.Click += EditJobButton_Click;
            removeJobButton.Click += RemoveJobButton_Click;
            viewChartButton.Click += ViewChartButton_Click;
            exportSettingsButton.Click += ExportSettingsButton_Click;
            importSettingsButton.Click += ImportSettingsButton_Click;
            startAllJobsButton.Click += StartAllJobsButton_Click;
            stopAllJobsButton.Click += StopAllJobsButton_Click;
            clearResultsButton.Click += ClearResultsButton_Click;

            jobList.DisplayMember = "Name";
            jobList.ValueMember = "Host";

            curJobPingList.DrawMode = DrawMode.OwnerDrawFixed;
            curJobPingList.DrawItem += CurJobPingList_DrawItem;
        }

        private void CurJobPingList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            Graphics g = e.Graphics;

            string item = curJobPingList.Items[e.Index].ToString();
            Color textColor = Color.Black;

            if (item.Contains("(High Latency)"))
            {
                textColor = Color.Orange;
            }
            else if (item.Contains("Failed"))
            {
                textColor = Color.Red;
            }
            else
            {
                textColor = Color.Green;
            }

            g.DrawString(item, e.Font, new SolidBrush(textColor), e.Bounds);
            e.DrawFocusRectangle();
        }

        private void SetupPingWorker()
        {
            pingWorker = new BackgroundWorker();
            pingWorker.WorkerSupportsCancellation = true;
            pingWorker.DoWork += PingWorker_DoWork;
            pingWorker.RunWorkerCompleted += PingWorker_RunWorkerCompleted;
        }

        private void PingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!pingWorker.CancellationPending)
            {
                List<PingJob> jobsCopy;
                lock (pingJobs)
                {
                    jobsCopy = new List<PingJob>(pingJobs);
                }

                foreach (var job in jobsCopy)
                {
                    if (pingWorker.CancellationPending) break;

                    PingReply reply = job.Ping();
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdatePingResult(job, reply);
                    });

                    System.Threading.Thread.Sleep(job.Interval);
                }
            }
        }

        private void UpdatePingResult(PingJob job, PingReply reply)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string currentResult = $"[{timestamp}] {job.Name}: ";

            if (reply.Status == IPStatus.Success)
            {
                currentResult += $"{reply.RoundtripTime}ms";
                if (reply.RoundtripTime > job.LatencyThreshold)
                {
                    currentResult += " (High)";
                    // TODO: Trigger alert
                }
            }
            else
            {
                currentResult += $"Failed ({reply.Status})";
                // TODO: Update consecutive failures and trigger alert if necessary
            }

            currentResult += $" | Loss: {job.ApproximatePacketLoss:F1}%";

            if (job.ApproximatePacketLoss > job.PacketLossThreshold)
            {
                currentResult += " (High Loss)";
                // TODO: Trigger alert
            }

            // Update curJobPingList
            int index = -1;
            for (int i = 0; i < curJobPingList.Items.Count; i++)
            {
                if (curJobPingList.Items[i].ToString().Contains(job.Name))
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                curJobPingList.Items[index] = currentResult;
            }
            else
            {
                curJobPingList.Items.Add(currentResult);
            }

            // Add to resultList at the top
            resultList.Items.Insert(0, currentResult);
            if (resultList.Items.Count > 100) // Keep only the last 100 results
            {
                resultList.Items.RemoveAt(resultList.Items.Count - 1);
            }

            curJobPingList.Refresh(); // Force redraw to update colors
        }

        private void PingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"An error occurred: {e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isRunning = false;
            UpdateButtonStates();
        }

        private void StartAllJobsButton_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                pingWorker.RunWorkerAsync();
                UpdateButtonStates();
            }
        }

        private void StopAllJobsButton_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                isRunning = false;
                pingWorker.CancelAsync();
                UpdateButtonStates();
            }
        }

        private void UpdateButtonStates()
        {
            startAllJobsButton.Enabled = !isRunning;
            stopAllJobsButton.Enabled = isRunning;
        }

        private void AddJobButton_Click(object sender, EventArgs e)
        {
            using (var addJobForm = new AddEditJobForm())
            {
                if (addJobForm.ShowDialog() == DialogResult.OK)
                {
                    lock (pingJobs)
                    {
                        pingJobs.Add(addJobForm.Job);
                    }
                    UpdateJobList();
                }
            }
        }

        private void EditJobButton_Click(object sender, EventArgs e)
        {
            if (jobList.SelectedItem is PingJob selectedJob)
            {
                using (var editJobForm = new AddEditJobForm(selectedJob))
                {
                    if (editJobForm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateJobList();
                    }
                }
            }
        }

        private void RemoveJobButton_Click(object sender, EventArgs e)
        {
            if (jobList.SelectedItem is PingJob selectedJob)
            {
                lock (pingJobs)
                {
                    pingJobs.Remove(selectedJob);
                }
                UpdateJobList();

                // Remove from curJobPingList
                for (int i = curJobPingList.Items.Count - 1; i >= 0; i--)
                {
                    if (curJobPingList.Items[i].ToString().Contains(selectedJob.Name))
                    {
                        curJobPingList.Items.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        private void ClearResultsButton_Click(object sender, EventArgs e)
        {
            resultList.Items.Clear();
        }

        private void UpdateJobList()
        {
            jobList.DataSource = null;
            lock (pingJobs)
            {
                jobList.DataSource = new List<PingJob>(pingJobs);
            }
        }

        private void ViewChartButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement view chart functionality
        }

        private void ExportSettingsButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement export settings functionality
        }

        private void ImportSettingsButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement import settings functionality
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (pingWorker.IsBusy)
            {
                pingWorker.CancelAsync();
                pingWorker.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}
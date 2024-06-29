using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Media;
using System.Net.Mail;

namespace PingBuddy
{
    public partial class MainForm : Form
    {
        private List<PingJob> pingJobs = new List<PingJob>();
        private BackgroundWorker pingWorker;
        private bool isRunning = false;
        private List<Alert> alertLog = new List<Alert>();
        private Dictionary<string, List<PingResult>> historicalData = new Dictionary<string, List<PingResult>>();
        private Settings appSettings;
        private DateTime lastNotificationEmailDateTime;

        public MainForm()
        {
            InitializeComponent();
            SetupCustomControls();
            SetupPingWorker();
            LoadSettings();
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
            clearAlertsButton.Click += ClearAlertsButton_Click;

            jobList.DisplayMember = "Name";
            jobList.ValueMember = "Host";

            curJobPingList.DrawMode = DrawMode.OwnerDrawFixed;
            curJobPingList.DrawItem += CurJobPingList_DrawItem;
            
            // Add a new button for notification settings
            Button notificationSettingsButton = new Button
            {
                Text = "Notification Settings",
                Location = new System.Drawing.Point(/* Set appropriate x and y values */),
                Size = new System.Drawing.Size(150, 30)
            };
            notificationSettingsButton.Click += NotificationSettingsButton_Click;
            this.Controls.Add(notificationSettingsButton);

            // Add settings menu item
            ToolStripMenuItem settingsMenuItem = new ToolStripMenuItem("Settings");
            settingsMenuItem.Click += SettingsMenuItem_Click;
            menuStrip.Items.Add(settingsMenuItem);
        }
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new NotificationSettingsForm(appSettings))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    appSettings = settingsForm.Settings;
                    SaveSettings();
                }
            }
        }
        private class PingResult
        {
            public DateTime Timestamp { get; set; }
            public long Latency { get; set; }
            public IPStatus Status { get; set; }
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
                    GenerateAlert(job, Alert.AlertType.HighLatency, $"High latency: {reply.RoundtripTime}ms");
                }
            }
            else
            {
                currentResult += $"Failed ({reply.Status})";
                GenerateAlert(job, Alert.AlertType.ConnectionLost, $"Connection lost: {reply.Status}");
            }

            currentResult += $" | Loss: {job.ApproximatePacketLoss:F1}%";

            if (job.ApproximatePacketLoss > job.PacketLossThreshold)
            {
                currentResult += " (High Loss)";
                GenerateAlert(job, Alert.AlertType.PacketLoss, $"High packet loss: {job.ApproximatePacketLoss:F1}%");
            }

            // Update curJobPingList
            UpdateCurJobPingList(job.Name, currentResult);

            // Add to resultList at the top
            resultList.Items.Insert(0, currentResult);
            if (resultList.Items.Count > 100) // Keep only the last 100 results
            {
                resultList.Items.RemoveAt(resultList.Items.Count - 1);
            }

            // Store historical data
            StoreHistoricalData(job.Name, reply);

            curJobPingList.Refresh(); // Force redraw to update colors
        }

        private void UpdateCurJobPingList(string jobName, string result)
        {
            for (int i = 0; i < curJobPingList.Items.Count; i++)
            {
                if (curJobPingList.Items[i].ToString().Contains(jobName))
                {
                    curJobPingList.Items[i] = result;
                    return;
                }
            }
            // If we didn't find an existing item for this job, add a new one
            curJobPingList.Items.Add(result);
        }

        private void GenerateAlert(PingJob job, Alert.AlertType type, string message)
        {
            var alert = new Alert(job.Name, message, type);
            alertLog.Add(alert);
            alertList.Items.Insert(0, alert.ToString());

            if (appSettings.UseSoundAlert)
            {
                PlayAlertSound();
            }

            if (appSettings.UseEmailNotification)
            {
                SendEmailAlert(alert);
            }
        }

        private void StoreHistoricalData(string jobName, PingReply reply)
        {
            if (!historicalData.ContainsKey(jobName))
            {
                historicalData[jobName] = new List<PingResult>();
            }

            historicalData[jobName].Add(new PingResult
            {
                Timestamp = DateTime.Now,
                Latency = reply.Status == IPStatus.Success ? reply.RoundtripTime : -1,
                Status = reply.Status
            });

            // Keep only last 24 hours of data
            var cutoffTime = DateTime.Now.AddHours(-24);
            historicalData[jobName] = historicalData[jobName].Where(r => r.Timestamp >= cutoffTime).ToList();
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

        private void ClearAlertsButton_Click(object sender, EventArgs e)
        {
            alertList.Items.Clear();
            alertLog.Clear();
        }

        private void UpdateJobList()
        {
            jobList.DataSource = null;
            lock (pingJobs)
            {
                jobList.DataSource = new List<PingJob>(pingJobs);
            }
            SaveSettings();

            // Update curJobPingList to reflect current jobs
            List<string> jobsToKeep = pingJobs.Select(j => j.Name).ToList();

            // Remove items for jobs that no longer exist
            for (int i = curJobPingList.Items.Count - 1; i >= 0; i--)
            {
                string itemText = curJobPingList.Items[i].ToString();
                string jobName = itemText.Split(':')[0].Trim().TrimStart('[').Split(']').Last().Trim();
                if (!jobsToKeep.Contains(jobName))
                {
                    curJobPingList.Items.RemoveAt(i);
                }
            }

            // Add placeholder items for new jobs
            foreach (var job in pingJobs)
            {
                if (!curJobPingList.Items.Cast<string>().Any(item => item.Contains(job.Name)))
                {
                    curJobPingList.Items.Add($"[{DateTime.Now:HH:mm:ss}] {job.Name}: Waiting for first ping...");
                }
            }
        }

        private void ViewChartButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement view chart functionality
        }

        private void ExportSettingsButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Settings settings = new Settings
                        {
                            PingJobs = pingJobs
                        };

                        string jsonString = JsonSerializer.Serialize(settings, new JsonSerializerOptions
                        {
                            WriteIndented = true
                        });

                        File.WriteAllText(saveFileDialog.FileName, jsonString);
                        MessageBox.Show("Settings exported successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting settings: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ImportSettingsButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string jsonString = File.ReadAllText(openFileDialog.FileName);
                        Settings settings = JsonSerializer.Deserialize<Settings>(jsonString);

                        if (settings != null && settings.PingJobs != null)
                        {
                            pingJobs = settings.PingJobs;
                            UpdateJobList();
                            MessageBox.Show("Settings imported successfully!", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The imported file doesn't contain valid settings.", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importing settings: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadSettings()
        {
            string settingsPath = Path.Combine(Application.StartupPath, "settings.json");
            if (File.Exists(settingsPath))
            {
                string jsonString = File.ReadAllText(settingsPath);
                appSettings = JsonSerializer.Deserialize<Settings>(jsonString);
            }
            else
            {
                appSettings = new Settings();
            }

            // Load ping jobs from settings
            pingJobs = appSettings.PingJobs ?? new List<PingJob>();
            UpdateJobList();
        }

        private void SaveSettings()
        {
            appSettings.PingJobs = pingJobs;
            string jsonString = JsonSerializer.Serialize(appSettings, new JsonSerializerOptions { WriteIndented = true });
            string settingsPath = Path.Combine(Application.StartupPath, "settings.json");
            File.WriteAllText(settingsPath, jsonString);
        }

        private void NotificationSettingsButton_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new NotificationSettingsForm(appSettings))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    appSettings = settingsForm.Settings;
                    SaveSettings(); // Implement this method to save settings to file
                }
            }
        }

        private void PlayAlertSound()
        {
            if (appSettings.UseSoundAlert)
            {
                try
                {
                    if (!string.IsNullOrEmpty(appSettings.SoundAlertFilePath) && File.Exists(appSettings.SoundAlertFilePath))
                    {
                        using (var player = new SoundPlayer(appSettings.SoundAlertFilePath))
                        {
                            player.Play();
                        }
                    }
                    else
                    {
                        SystemSounds.Exclamation.Play();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error playing alert sound: {ex.Message}");
                }
            }
        }

        private void SendEmailAlert(Alert alert)
        {
            // First, check if email notifications are enabled
            if (!appSettings.UseEmailNotification)
                return;

            // Check if enough time has passed to send a new email
            TimeSpan elapsedEmailTime = DateTime.Now - lastNotificationEmailDateTime;
            if (elapsedEmailTime.TotalMinutes < appSettings.EmailMinuteLimit)
                return;

            // Check if all necessary email parameters are set
            if (string.IsNullOrWhiteSpace(appSettings.EmailSmtpServer) ||
                appSettings.EmailSmtpPort == 0 ||
                string.IsNullOrWhiteSpace(appSettings.EmailUsername) ||
                string.IsNullOrWhiteSpace(appSettings.EmailPassword) ||
                string.IsNullOrWhiteSpace(appSettings.EmailFromAddress) ||
                string.IsNullOrWhiteSpace(appSettings.EmailToAddress))
            {
                // Log this issue or show a message to the user
                Console.WriteLine("Email alert not sent: Email settings are incomplete.");
                return;
            }

            try
            {
                using (SmtpClient smtpClient = new SmtpClient(appSettings.EmailSmtpServer, appSettings.EmailSmtpPort))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential(appSettings.EmailUsername, appSettings.EmailPassword);
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(appSettings.EmailFromAddress);
                    mailMessage.To.Add(appSettings.EmailToAddress);
                    mailMessage.Subject = $"Ping Alert: {alert.JobName}";
                    mailMessage.Body = alert.ToString();

                    smtpClient.Send(mailMessage);

                    // update the last sent email DateTime
                    lastNotificationEmailDateTime = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                // Log the error or show a message to the user
                Console.WriteLine($"Error sending email alert: {ex.Message}");
                // Optionally, you can show a message box or log this error
                // MessageBox.Show($"Error sending email alert: {ex.Message}", "Email Alert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
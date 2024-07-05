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
using System.Formats.Asn1;
using CsvHelper;
using CsvHelper.Configuration;

namespace PingBuddy
{
    public partial class MainForm : Form
    {
        private List<PingJob> pingJobs = new List<PingJob>();
        private List<ScheduledJob> scheduledJobs = new List<ScheduledJob>();
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
            LoadScheduledJobs();
            UpdateAlertList();
            UpdateResultList();
            WireUpMenuItems();
        }
        private void LoadScheduledJobs()
        {
            string scheduledJobsPath = Path.Combine(Application.StartupPath, "scheduledJobs.json");
            if (File.Exists(scheduledJobsPath))
            {
                string jsonString = File.ReadAllText(scheduledJobsPath);
                var loadedJobs = JsonSerializer.Deserialize<List<ScheduledJobSaveData>>(jsonString);

                scheduledJobs.Clear();
                foreach (var loadedJob in loadedJobs)
                {
                    var matchingPingJob = pingJobs.FirstOrDefault(j => j.Name == loadedJob.JobName);
                    if (matchingPingJob != null)
                    {
                        scheduledJobs.Add(new ScheduledJob(
                            matchingPingJob,
                            loadedJob.StartTime,
                            loadedJob.Duration,
                            loadedJob.Status,
                            loadedJob.OutputFolder
                        ));
                    }
                }

                UpdateScheduledJobList();
            }
        }
        private void SaveScheduledJobs()
        {
            var jobsToSave = scheduledJobs.Select(sj => new ScheduledJobSaveData
            {
                JobName = sj.Job.Name,
                StartTime = sj.StartTime,
                Duration = sj.Duration,
                Status = sj.Status,
                OutputFolder = sj.OutputFolder
            }).ToList();

            string jsonString = JsonSerializer.Serialize(jobsToSave, new JsonSerializerOptions { WriteIndented = true });
            string scheduledJobsPath = Path.Combine(Application.StartupPath, "scheduledJobs.json");
            File.WriteAllText(scheduledJobsPath, jsonString);
        }
        private void ExportJobResults(PingJob job, string outputFolder)
        {
            // Implement the logic to export job results to the specified output folder
            // This method should be called when a scheduled job completes
        }
        private void SetupCustomControls()
        {
            addJobButton.Click += AddJobButton_Click;
            editJobButton.Click += EditJobButton_Click;
            removeJobButton.Click += RemoveJobButton_Click;
            viewChartButton.Click += ViewChartButton_Click;
            startAllJobsButton.Click += StartAllJobsButton_Click;
            stopAllJobsButton.Click += StopAllJobsButton_Click;
            clearResultsButton.Click += ClearResultsButton_Click;
            clearAlertsButton.Click += ClearAlertsButton_Click;
            scheduleJobButton.Click += ScheduleJobButton_Click;

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

            // jobFilterComboBox
            jobFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            jobFilterComboBox.Items.Add("All");
            jobFilterComboBox.SelectedIndex = 0; // Default to "All"
            jobFilterComboBox.SelectedIndexChanged += JobFilterComboBox_SelectedIndexChanged;
            UpdateJobFilterComboBox();
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
                List<PingJob> allJobs;
                lock (pingJobs)
                {
                    allJobs = new List<PingJob>(pingJobs);
                    allJobs.AddRange(scheduledJobs.Where(j => j.ShouldBeRunning()).Select(j => j.Job));
                }

                foreach (var job in allJobs)
                {
                    if (pingWorker.CancellationPending) break;

                    PingReply? reply = job.Ping();
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdatePingResult(job, reply);
                    });

                    System.Threading.Thread.Sleep(job.Interval);
                }

                // Check for completed scheduled jobs
                var completedJobs = scheduledJobs.Where(j => DateTime.Now >= j.StartTime.Add(j.Duration)).ToList();
                foreach (var job in completedJobs)
                {
                    ExportJobResults(job.Job);
                    scheduledJobs.Remove(job);
                }
                if (completedJobs.Any())
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateScheduledJobList();
                    });
                }
            }
        }
        private void UpdatePingResult(PingJob job, PingReply? reply)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string currentResult = $"[{timestamp}] {job.Name}: ";

            if (reply != null && reply.Status == IPStatus.Success)
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
                currentResult += $"Failed ({reply?.Status ?? IPStatus.Unknown})";
                GenerateAlert(job, Alert.AlertType.ConnectionLost, $"Connection lost: {reply?.Status ?? IPStatus.Unknown}");
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
            UpdateFilteredLists(); // Update the filter dropdown
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
        private void UpdateCurrentJobPingList()
        {
            curJobPingList.Items.Clear();
            foreach (var job in pingJobs)
            {
                var latestResult = job.PingResults.OrderByDescending(r => r.Timestamp).FirstOrDefault();
                if (latestResult != null)
                {
                    string status = latestResult.Status == IPStatus.Success ? "Success" : "Failed";
                    curJobPingList.Items.Add($"{job.Name}: {status} - {latestResult.Latency}ms");
                }
            }
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
            UpdateFilteredLists(); // Update the list when a new alert is generated.
        }
        private void UpdateResultList()
        {
            resultList.Items.Clear();
            foreach (var job in pingJobs)
            {
                foreach (var result in job.PingResults.OrderByDescending(r => r.Timestamp).Take(100)) // Show last 100 results
                {
                    resultList.Items.Add($"{result.Timestamp} - {job.Name}: {result.Status} - {result.Latency}ms");
                }
            }
            UpdateJobFilterComboBox();
        }
        private void UpdateAlertList()
        {
            alertList.Items.Clear();
            foreach (var job in pingJobs)
            {
                foreach (var result in job.PingResults.Where(r => r.AlertType.HasValue).OrderByDescending(r => r.Timestamp).Take(100)) // Show last 100 alerts
                {
                    alertList.Items.Add($"{result.Timestamp} - {job.Name}: {result.AlertType} - {result.AlertMessage}");
                }
            }
            UpdateJobFilterComboBox();
        }
        private void StoreHistoricalData(string jobName, PingReply? reply)
        {
            if (!historicalData.ContainsKey(jobName))
            {
                historicalData[jobName] = new List<PingResult>();
            }

            historicalData[jobName].Add(new PingResult
            {
                Timestamp = DateTime.Now,
                Latency = reply?.Status == IPStatus.Success ? reply.RoundtripTime : -1,
                Status = reply?.Status ?? IPStatus.Unknown
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
        private void OpenVisualizationForm()
        {
            var visualizationForm = new VisualizationForm();
            visualizationForm.PopulateJobList(pingJobs);
            visualizationForm.Show();
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
            string selectedFilter = jobFilterComboBox.SelectedItem?.ToString() ?? "All";

            if (selectedFilter == "All")
            {
                resultList.Items.Clear();
                foreach (var job in pingJobs)
                {
                    job.ClearResults();
                }
            }
            else
            {
                var selectedJob = pingJobs.FirstOrDefault(job => job.Name == selectedFilter);
                if (selectedJob != null)
                {
                    selectedJob.ClearResults();

                    // Remove only the results for the selected job from the resultList
                    for (int i = resultList.Items.Count - 1; i >= 0; i--)
                    {
                        if (resultList.Items[i].ToString().Contains(selectedJob.Name))
                        {
                            resultList.Items.RemoveAt(i);
                        }
                    }
                }
            }

            UpdateFilteredLists();
        }
        private void ClearAlertsButton_Click(object sender, EventArgs e)
        {
            string selectedFilter = jobFilterComboBox.SelectedItem?.ToString() ?? "All";

            if (selectedFilter == "All")
            {
                alertList.Items.Clear();
                alertLog.Clear();
                foreach (var job in pingJobs)
                {
                    job.ClearAlerts();
                }
            }
            else
            {
                var selectedJob = pingJobs.FirstOrDefault(job => job.Name == selectedFilter);
                if (selectedJob != null)
                {
                    selectedJob.ClearAlerts();

                    // Remove only the alerts for the selected job from the alertLog
                    alertLog.RemoveAll(alert => alert.JobName == selectedJob.Name);

                    // Remove only the alerts for the selected job from the alertList
                    for (int i = alertList.Items.Count - 1; i >= 0; i--)
                    {
                        if (alertList.Items[i].ToString().Contains(selectedJob.Name))
                        {
                            alertList.Items.RemoveAt(i);
                        }
                    }
                }
            }

            UpdateFilteredLists();
        }
        private void UpdateJobList()
        {
            jobList.DataSource = null;
            jobList.DataSource = new BindingList<PingJob>(pingJobs);
            jobList.DisplayMember = "Name";
            jobList.ValueMember = "Host";
            UpdateJobFilterComboBox();
        }
        private void UpdateJobFilterComboBox()
        {
            jobFilterComboBox.Items.Clear();
            jobFilterComboBox.Items.Add("All");
            foreach (var job in pingJobs)
            {
                jobFilterComboBox.Items.Add(job.Name);
            }
        }
        private void ViewChartButton_Click(object sender, EventArgs e)
        {
            OpenVisualizationForm();
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

            // Load alert history from settings
            alertLog = appSettings.AlertHistory ?? new List<Alert>();

            UpdateJobList();
            UpdateAlertList();
            UpdateFilteredLists();
        }
        private void SaveSettings()
        {
            appSettings.PingJobs = pingJobs;
            appSettings.AlertHistory = alertLog;
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
                    SaveSettings();
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
        private void WireUpMenuItems()
        {
            importJobsToolStripMenuItem.Click += ImportJobsToolStripMenuItem_Click;
            exportJobsToolStripMenuItem.Click += ExportJobsToolStripMenuItem_Click;
            importPingHistoryToolStripMenuItem.Click += ImportPingHistoryToolStripMenuItem_Click;
            exportPingHistoryToolStripMenuItem.Click += ExportPingHistoryToolStripMenuItem_Click;
            networkDetailMenuItem.Click += networkDetailMenuItem_Click;
        }
        private void ImportJobsToolStripMenuItem_Click(object sender, EventArgs e)
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
                            MessageBox.Show("Jobs imported successfully!", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The imported file doesn't contain valid jobs.", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importing jobs: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ExportJobsToolStripMenuItem_Click(object sender, EventArgs e)
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
                        MessageBox.Show("Jobs exported successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting jobs: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ImportPingHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var reader = new StreamReader(openFileDialog.FileName))
                        using (var csv = new CsvReader(reader, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
                        {
                            var records = csv.GetRecords<PingHistoryRecord>().ToList();

                            pingJobs.Clear();

                            foreach (var record in records)
                            {
                                // Find or create job
                                var job = pingJobs.FirstOrDefault(j => j.Name == record.JobName);
                                if (job == null)
                                {
                                    job = new PingJob { Name = record.JobName, Host = record.Host };
                                    pingJobs.Add(job);
                                }

                                // Add ping result
                                var result = new PingResult
                                {
                                    Timestamp = record.Timestamp,
                                    Status = Enum.Parse<IPStatus>(record.Status),
                                    Latency = record.Latency
                                };

                                // Add alert if present
                                if (!string.IsNullOrEmpty(record.AlertType))
                                {
                                    result.AlertType = Enum.Parse<Alert.AlertType>(record.AlertType);
                                    result.AlertMessage = record.AlertMessage;
                                }

                                job.PingResults.Add(result);
                            }

                            UpdateJobList();
                            UpdateCurrentJobPingList();
                            UpdateResultList();
                            UpdateAlertList();

                            MessageBox.Show("Ping history imported successfully!", "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importing ping history: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ExportPingHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var writer = new StreamWriter(saveFileDialog.FileName))
                        using (var csv = new CsvWriter(writer, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
                        {
                            // Write header
                            csv.WriteField("Timestamp");
                            csv.WriteField("Job Name");
                            csv.WriteField("Host");
                            csv.WriteField("Status");
                            csv.WriteField("Latency (ms)");
                            csv.WriteField("Alert Type");
                            csv.WriteField("Alert Message");
                            csv.NextRecord();

                            // Write data
                            foreach (var job in pingJobs)
                            {
                                foreach (var result in job.PingResults)
                                {
                                    csv.WriteField(result.Timestamp);
                                    csv.WriteField(job.Name);
                                    csv.WriteField(job.Host);
                                    csv.WriteField(result.Status);
                                    csv.WriteField(result.Latency);
                                    csv.WriteField(result.AlertType?.ToString() ?? "");
                                    csv.WriteField(result.AlertMessage ?? "");
                                    csv.NextRecord();
                                }
                            }
                        }

                        MessageBox.Show("Ping history exported successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting ping history: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void networkDetailMenuItem_Click(object sender, EventArgs e)
        {
            NetworkDetailsForm networkDetailsForm = new NetworkDetailsForm();
            networkDetailsForm.Show(); // This shows the form without closing the main form
        }
        private void ScheduleJobButton_Click(object sender, EventArgs e)
        {
            using (var scheduleForm = new ScheduleJobForm(pingJobs, scheduledJobs))
            {
                if (scheduleForm.ShowDialog() == DialogResult.OK)
                {
                    scheduledJobs = scheduleForm.GetScheduledJobs();
                    SaveScheduledJobs();
                    UpdateScheduledJobList();
                }
            }
        }
        private void UpdateScheduledJobList()
        {
            // Update UI to show scheduled jobs (you might want to add a new ListBox for this)
            // For now, we'll just update the status strip
            statusLabel.Text = $"Scheduled Jobs: {scheduledJobs.Count}";
        }
        private void ExportJobResults(PingJob job)
        {
            string fileName = $"{job.Name}_{job.ScheduledStartTime:yyyyMMdd_HHmmss}.csv";
            string filePath = Path.Combine(Application.StartupPath, "ScheduledJobResults", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvHelper.CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(job.PingResults);
            }
        }
        private void JobFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilteredLists();
        }
        private void UpdateFilteredLists()
        {
            string selectedFilter = jobFilterComboBox.SelectedItem?.ToString() ?? "All";

            // Clear and repopulate resultList
            resultList.Items.Clear();
            foreach (var job in pingJobs)
            {
                if (selectedFilter == "All" || selectedFilter == job.Name)
                {
                    foreach (var result in job.PingResults.OrderByDescending(r => r.Timestamp).Take(100))
                    {
                        resultList.Items.Add($"{result.Timestamp} - {job.Name}: {result.Status} - {result.Latency}ms");
                    }
                }
            }

            // Clear and repopulate alertList
            alertList.Items.Clear();
            foreach (var alert in alertLog)
            {
                if (selectedFilter == "All" || selectedFilter == alert.JobName)
                {
                    alertList.Items.Add(alert.ToString());
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (pingWorker.IsBusy)
            {
                pingWorker.CancelAsync();
                pingWorker.Dispose();
            }
            SaveSettings();
            base.OnFormClosing(e);
        }

        private void jobFilterComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
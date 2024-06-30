using System;
using System.Windows.Forms;

namespace PingBuddy
{
    public partial class AddEditJobForm : Form
    {
        public PingJob Job { get; private set; }

        public AddEditJobForm(PingJob job = null)
        {
            InitializeComponent();
            Job = job ?? new PingJob();
            SetupNumericUpDownControls();
            LoadJobData();
        }

        private void SetupNumericUpDownControls()
        {
            intervalNumericUpDown.Minimum = 100;
            intervalNumericUpDown.Maximum = 60000;

            timeoutNumericUpDown.Minimum = 100;
            timeoutNumericUpDown.Maximum = 60000;

            bufferSizeNumericUpDown.Minimum = 1;
            bufferSizeNumericUpDown.Maximum = 65500;

            latencyThresholdNumericUpDown.Minimum = 1;
            latencyThresholdNumericUpDown.Maximum = 10000;

            packetLossThresholdNumericUpDown.Minimum = 0;
            packetLossThresholdNumericUpDown.Maximum = 100;
            packetLossThresholdNumericUpDown.DecimalPlaces = 2;

            consecutiveFailuresNumericUpDown.Minimum = 1;
            consecutiveFailuresNumericUpDown.Maximum = 100;
        }

        private void LoadJobData()
        {
            nameTextBox.Text = Job.Name;
            hostTextBox.Text = Job.Host;
            intervalNumericUpDown.Value = Math.Max(intervalNumericUpDown.Minimum, Math.Min(intervalNumericUpDown.Maximum, Job.Interval));
            timeoutNumericUpDown.Value = Math.Max(timeoutNumericUpDown.Minimum, Math.Min(timeoutNumericUpDown.Maximum, Job.Timeout));
            bufferSizeNumericUpDown.Value = Math.Max(bufferSizeNumericUpDown.Minimum, Math.Min(bufferSizeNumericUpDown.Maximum, Job.BufferSize));
            latencyThresholdNumericUpDown.Value = Math.Max(latencyThresholdNumericUpDown.Minimum, Math.Min(latencyThresholdNumericUpDown.Maximum, Job.LatencyThreshold));
            packetLossThresholdNumericUpDown.Value = (decimal)Math.Max((double)packetLossThresholdNumericUpDown.Minimum, Math.Min((double)packetLossThresholdNumericUpDown.Maximum, Job.PacketLossThreshold));
            consecutiveFailuresNumericUpDown.Value = Math.Max(consecutiveFailuresNumericUpDown.Minimum, Math.Min(consecutiveFailuresNumericUpDown.Maximum, Job.ConsecutiveFailures));
            playSoundCheckBox.Checked = Job.PlaySoundOnAlert;
            sendEmailCheckBox.Checked = Job.SendEmailOnAlert;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hostTextBox.Text))
            {
                MessageBox.Show("Host cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Job.Name = string.IsNullOrWhiteSpace(nameTextBox.Text) ? hostTextBox.Text : nameTextBox.Text;
            Job.Host = hostTextBox.Text;
            Job.Interval = (int)intervalNumericUpDown.Value;
            Job.Timeout = (int)timeoutNumericUpDown.Value;
            Job.BufferSize = (int)bufferSizeNumericUpDown.Value;
            Job.LatencyThreshold = (int)latencyThresholdNumericUpDown.Value;
            Job.PacketLossThreshold = (double)packetLossThresholdNumericUpDown.Value;
            Job.ConsecutiveFailures = (int)consecutiveFailuresNumericUpDown.Value;
            Job.PlaySoundOnAlert = playSoundCheckBox.Checked;
            Job.SendEmailOnAlert = sendEmailCheckBox.Checked;

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
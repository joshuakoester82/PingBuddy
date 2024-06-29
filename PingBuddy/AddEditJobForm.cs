using System;
using System.Drawing;
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

        private void InitializeComponent()
        {
            this.Text = "Add/Edit Ping Job";
            this.Size = new Size(500, 620);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Create controls
            nameTextBox = CreateTextBox(30, "Name:");
            hostTextBox = CreateTextBox(70, "Host:");
            intervalNumericUpDown = CreateNumericUpDown(110, "Interval (ms):");
            timeoutNumericUpDown = CreateNumericUpDown(150, "Timeout (ms):");
            bufferSizeNumericUpDown = CreateNumericUpDown(190, "Buffer Size (bytes):");
            latencyThresholdNumericUpDown = CreateNumericUpDown(230, "Latency Threshold (ms):");
            packetLossThresholdNumericUpDown = CreateNumericUpDown(270, "Packet Loss Threshold (%):");
            consecutiveFailuresNumericUpDown = CreateNumericUpDown(310, "Consecutive Failures:");

            playSoundCheckBox = CreateCheckBox(350, "Play Sound on Alert");
            sendEmailCheckBox = CreateCheckBox(390, "Send Email on Alert");

            saveButton = new Button
            {
                Text = "Save",
                Location = new Point(150, 520),
                Size = new Size(100, 30)
            };
            saveButton.Click += SaveButton_Click;
            this.Controls.Add(saveButton);

            cancelButton = new Button
            {
                Text = "Cancel",
                Location = new Point(270, 520),
                Size = new Size(100, 30)
            };
            cancelButton.Click += CancelButton_Click;
            this.Controls.Add(cancelButton);

            this.AcceptButton = saveButton;
            this.CancelButton = cancelButton;
        }

        private TextBox CreateTextBox(int y, string labelText)
        {
            var label = new Label
            {
                Text = labelText,
                Location = new Point(30, y),
                Size = new Size(150, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(label);

            var textBox = new TextBox
            {
                Location = new Point(200, y),
                Size = new Size(250, 20)
            };
            this.Controls.Add(textBox);

            return textBox;
        }

        private NumericUpDown CreateNumericUpDown(int y, string labelText)
        {
            var label = new Label
            {
                Text = labelText,
                Location = new Point(30, y),
                Size = new Size(150, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(label);

            var numericUpDown = new NumericUpDown
            {
                Location = new Point(200, y),
                Size = new Size(250, 20)
            };
            this.Controls.Add(numericUpDown);

            return numericUpDown;
        }

        private CheckBox CreateCheckBox(int y, string text)
        {
            var checkBox = new CheckBox
            {
                Text = text,
                Location = new Point(30, y),
                Size = new Size(400, 24)
            };
            this.Controls.Add(checkBox);

            return checkBox;
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

        // Declare controls
        private TextBox nameTextBox;
        private TextBox hostTextBox;
        private NumericUpDown intervalNumericUpDown;
        private NumericUpDown timeoutNumericUpDown;
        private NumericUpDown bufferSizeNumericUpDown;
        private NumericUpDown latencyThresholdNumericUpDown;
        private NumericUpDown packetLossThresholdNumericUpDown;
        private NumericUpDown consecutiveFailuresNumericUpDown;
        private CheckBox playSoundCheckBox;
        private CheckBox sendEmailCheckBox;
        private Button saveButton;
        private Button cancelButton;
    }
}
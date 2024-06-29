using System;
using System.Windows.Forms;

namespace PingBuddy
{
    public partial class NotificationSettingsForm : Form
    {
        public Settings Settings { get; private set; }

        public NotificationSettingsForm(Settings currentSettings)
        {
            InitializeComponent();
            Settings = currentSettings ?? new Settings();
            LoadSettings();
            cancelButton.Click += (sender, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void LoadSettings()
        {
            useEmailNotificationCheckBox.Checked = Settings.UseEmailNotification;
            smtpServerTextBox.Text = Settings.EmailSmtpServer;
            smtpPortTextBox.Text = Settings.EmailSmtpPort.ToString();
            usernameTextBox.Text = Settings.EmailUsername;
            passwordTextBox.Text = Settings.EmailPassword;
            fromAddressTextBox.Text = Settings.EmailFromAddress;
            toAddressTextBox.Text = Settings.EmailToAddress;
            useSoundAlertCheckBox.Checked = Settings.UseSoundAlert;
            soundFilePathTextBox.Text = Settings.SoundAlertFilePath;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Settings.UseEmailNotification = useEmailNotificationCheckBox.Checked;
            Settings.EmailSmtpServer = smtpServerTextBox.Text;
            Settings.EmailSmtpPort = int.TryParse(smtpPortTextBox.Text, out int port) ? port : 587;
            Settings.EmailUsername = usernameTextBox.Text;
            Settings.EmailPassword = passwordTextBox.Text;
            Settings.EmailFromAddress = fromAddressTextBox.Text;
            Settings.EmailToAddress = toAddressTextBox.Text;
            Settings.UseSoundAlert = useSoundAlertCheckBox.Checked;
            Settings.SoundAlertFilePath = soundFilePathTextBox.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void BrowseSoundFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "WAV files (*.wav)|*.wav|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    soundFilePathTextBox.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
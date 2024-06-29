using System;
using System.Net.Mail;
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

        private void EmailTestButton_Click(object sender, EventArgs e)
        {
            
            string emailSmtpServer = smtpServerTextBox.Text;
             int emailSmtpPort = int.TryParse(smtpPortTextBox.Text, out int port) ? port : 587;
             string emailUsername = usernameTextBox.Text;
             string emailPassword = passwordTextBox.Text;
             string emailFromAddress = fromAddressTextBox.Text;
             string emailtoAddress = toAddressTextBox.Text;
            

            // Check if all necessary email parameters are set
            if (string.IsNullOrWhiteSpace(emailSmtpServer) ||
                emailSmtpPort == 0 ||
                string.IsNullOrWhiteSpace(emailUsername) ||
                string.IsNullOrWhiteSpace(emailPassword) ||
                string.IsNullOrWhiteSpace(emailFromAddress) ||
                string.IsNullOrWhiteSpace(emailtoAddress))
            {
                // Log this issue or show a message to the user
                Console.WriteLine("Email alert not sent: Email settings are incomplete.");
                return;
            }

            try
            {
                using (SmtpClient smtpClient = new SmtpClient(emailSmtpServer, emailSmtpPort))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential(emailUsername, emailPassword);
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(emailFromAddress);
                    mailMessage.To.Add(emailtoAddress);
                    mailMessage.Subject = $"Ping Buddy test email.";
                    var now = DateTime.Now;
                    mailMessage.Body = $"Test email sent: {now}";

                    smtpClient.Send(mailMessage);

                    MessageBox.Show("Email notification sent, hypothetically. I didn't really check.");
                }
            }
            catch (Exception ex)
            {
                // Log the error or show a message to the user
                Console.WriteLine($"Error sending email alert: {ex.Message}");
                // Optionally, you can show a message box or log this error
                MessageBox.Show($"Error sending email alert: {ex.Message}", "Email Alert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
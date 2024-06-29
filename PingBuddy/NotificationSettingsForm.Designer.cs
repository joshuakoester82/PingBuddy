namespace PingBuddy
{
    partial class NotificationSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            smtpServerTextBox = new TextBox();
            smtpPortTextBox = new TextBox();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            fromAddressTextBox = new TextBox();
            toAddressTextBox = new TextBox();
            useEmailNotificationCheckBox = new CheckBox();
            soundFilePathTextBox = new TextBox();
            browseSoundFileButton = new Button();
            useSoundAlertCheckBox = new CheckBox();
            saveButton = new Button();
            cancelButton = new Button();
            smtpServerLabel = new Label();
            smtpPortLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            fromAddressLabel = new Label();
            toAddressLabel = new Label();
            soundFileLabel = new Label();
            emailtestButton = new Button();
            textBoxEmailMinuteLimit = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // smtpServerTextBox
            // 
            smtpServerTextBox.Location = new Point(217, 96);
            smtpServerTextBox.Margin = new Padding(5, 6, 5, 6);
            smtpServerTextBox.Name = "smtpServerTextBox";
            smtpServerTextBox.Size = new Size(318, 31);
            smtpServerTextBox.TabIndex = 1;
            // 
            // smtpPortTextBox
            // 
            smtpPortTextBox.Location = new Point(217, 154);
            smtpPortTextBox.Margin = new Padding(5, 6, 5, 6);
            smtpPortTextBox.Name = "smtpPortTextBox";
            smtpPortTextBox.Size = new Size(318, 31);
            smtpPortTextBox.TabIndex = 2;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(217, 212);
            usernameTextBox.Margin = new Padding(5, 6, 5, 6);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(318, 31);
            usernameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(217, 269);
            passwordTextBox.Margin = new Padding(5, 6, 5, 6);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(318, 31);
            passwordTextBox.TabIndex = 4;
            // 
            // fromAddressTextBox
            // 
            fromAddressTextBox.Location = new Point(217, 327);
            fromAddressTextBox.Margin = new Padding(5, 6, 5, 6);
            fromAddressTextBox.Name = "fromAddressTextBox";
            fromAddressTextBox.Size = new Size(318, 31);
            fromAddressTextBox.TabIndex = 5;
            // 
            // toAddressTextBox
            // 
            toAddressTextBox.Location = new Point(217, 385);
            toAddressTextBox.Margin = new Padding(5, 6, 5, 6);
            toAddressTextBox.Name = "toAddressTextBox";
            toAddressTextBox.Size = new Size(318, 31);
            toAddressTextBox.TabIndex = 6;
            // 
            // useEmailNotificationCheckBox
            // 
            useEmailNotificationCheckBox.AutoSize = true;
            useEmailNotificationCheckBox.Location = new Point(33, 38);
            useEmailNotificationCheckBox.Margin = new Padding(5, 6, 5, 6);
            useEmailNotificationCheckBox.Name = "useEmailNotificationCheckBox";
            useEmailNotificationCheckBox.Size = new Size(211, 29);
            useEmailNotificationCheckBox.TabIndex = 0;
            useEmailNotificationCheckBox.Text = "Use Email Notification";
            useEmailNotificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // soundFilePathTextBox
            // 
            soundFilePathTextBox.Location = new Point(217, 635);
            soundFilePathTextBox.Margin = new Padding(5, 6, 5, 6);
            soundFilePathTextBox.Name = "soundFilePathTextBox";
            soundFilePathTextBox.Size = new Size(331, 31);
            soundFilePathTextBox.TabIndex = 8;
            // 
            // browseSoundFileButton
            // 
            browseSoundFileButton.Location = new Point(567, 631);
            browseSoundFileButton.Margin = new Padding(5, 6, 5, 6);
            browseSoundFileButton.Name = "browseSoundFileButton";
            browseSoundFileButton.Size = new Size(125, 44);
            browseSoundFileButton.TabIndex = 9;
            browseSoundFileButton.Text = "Browse";
            browseSoundFileButton.UseVisualStyleBackColor = true;
            browseSoundFileButton.Click += BrowseSoundFileButton_Click;
            // 
            // useSoundAlertCheckBox
            // 
            useSoundAlertCheckBox.AutoSize = true;
            useSoundAlertCheckBox.Location = new Point(33, 578);
            useSoundAlertCheckBox.Margin = new Padding(5, 6, 5, 6);
            useSoundAlertCheckBox.Name = "useSoundAlertCheckBox";
            useSoundAlertCheckBox.Size = new Size(166, 29);
            useSoundAlertCheckBox.TabIndex = 7;
            useSoundAlertCheckBox.Text = "Use Sound Alert";
            useSoundAlertCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(217, 712);
            saveButton.Margin = new Padding(5, 6, 5, 6);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(125, 44);
            saveButton.TabIndex = 10;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(367, 712);
            cancelButton.Margin = new Padding(5, 6, 5, 6);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(125, 44);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // smtpServerLabel
            // 
            smtpServerLabel.AutoSize = true;
            smtpServerLabel.Location = new Point(33, 102);
            smtpServerLabel.Margin = new Padding(5, 0, 5, 0);
            smtpServerLabel.Name = "smtpServerLabel";
            smtpServerLabel.Size = new Size(115, 25);
            smtpServerLabel.TabIndex = 12;
            smtpServerLabel.Text = "SMTP Server:";
            // 
            // smtpPortLabel
            // 
            smtpPortLabel.AutoSize = true;
            smtpPortLabel.Location = new Point(33, 160);
            smtpPortLabel.Margin = new Padding(5, 0, 5, 0);
            smtpPortLabel.Name = "smtpPortLabel";
            smtpPortLabel.Size = new Size(98, 25);
            smtpPortLabel.TabIndex = 13;
            smtpPortLabel.Text = "SMTP Port:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(33, 217);
            usernameLabel.Margin = new Padding(5, 0, 5, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(95, 25);
            usernameLabel.TabIndex = 14;
            usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(33, 275);
            passwordLabel.Margin = new Padding(5, 0, 5, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(91, 25);
            passwordLabel.TabIndex = 15;
            passwordLabel.Text = "Password:";
            // 
            // fromAddressLabel
            // 
            fromAddressLabel.AutoSize = true;
            fromAddressLabel.Location = new Point(33, 333);
            fromAddressLabel.Margin = new Padding(5, 0, 5, 0);
            fromAddressLabel.Name = "fromAddressLabel";
            fromAddressLabel.Size = new Size(128, 25);
            fromAddressLabel.TabIndex = 16;
            fromAddressLabel.Text = "From Address:";
            // 
            // toAddressLabel
            // 
            toAddressLabel.AutoSize = true;
            toAddressLabel.Location = new Point(33, 390);
            toAddressLabel.Margin = new Padding(5, 0, 5, 0);
            toAddressLabel.Name = "toAddressLabel";
            toAddressLabel.Size = new Size(104, 25);
            toAddressLabel.TabIndex = 17;
            toAddressLabel.Text = "To Address:";
            // 
            // soundFileLabel
            // 
            soundFileLabel.AutoSize = true;
            soundFileLabel.Location = new Point(33, 641);
            soundFileLabel.Margin = new Padding(5, 0, 5, 0);
            soundFileLabel.Name = "soundFileLabel";
            soundFileLabel.Size = new Size(99, 25);
            soundFileLabel.TabIndex = 18;
            soundFileLabel.Text = "Sound File:";
            // 
            // emailtestButton
            // 
            emailtestButton.Location = new Point(33, 453);
            emailtestButton.Margin = new Padding(5, 6, 5, 6);
            emailtestButton.Name = "emailtestButton";
            emailtestButton.Size = new Size(166, 44);
            emailtestButton.TabIndex = 19;
            emailtestButton.Text = "Send Test Email";
            emailtestButton.UseVisualStyleBackColor = true;
            emailtestButton.Click += EmailTestButton_Click;
            // 
            // textBoxEmailMinuteLimit
            // 
            textBoxEmailMinuteLimit.Location = new Point(434, 460);
            textBoxEmailMinuteLimit.Margin = new Padding(5, 6, 5, 6);
            textBoxEmailMinuteLimit.Name = "textBoxEmailMinuteLimit";
            textBoxEmailMinuteLimit.Size = new Size(69, 31);
            textBoxEmailMinuteLimit.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(217, 463);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(217, 25);
            label1.TabIndex = 21;
            label1.Text = "Limit emails to once every";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(513, 463);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(75, 25);
            label2.TabIndex = 22;
            label2.Text = "minutes";
            // 
            // NotificationSettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 787);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxEmailMinuteLimit);
            Controls.Add(emailtestButton);
            Controls.Add(soundFileLabel);
            Controls.Add(toAddressLabel);
            Controls.Add(fromAddressLabel);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(smtpPortLabel);
            Controls.Add(smtpServerLabel);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(useSoundAlertCheckBox);
            Controls.Add(browseSoundFileButton);
            Controls.Add(soundFilePathTextBox);
            Controls.Add(useEmailNotificationCheckBox);
            Controls.Add(toAddressTextBox);
            Controls.Add(fromAddressTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(smtpPortTextBox);
            Controls.Add(smtpServerTextBox);
            Margin = new Padding(5, 6, 5, 6);
            Name = "NotificationSettingsForm";
            Text = "Notification Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox smtpServerTextBox;
        private System.Windows.Forms.TextBox smtpPortTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox fromAddressTextBox;
        private System.Windows.Forms.TextBox toAddressTextBox;
        private System.Windows.Forms.CheckBox useEmailNotificationCheckBox;
        private System.Windows.Forms.TextBox soundFilePathTextBox;
        private System.Windows.Forms.Button browseSoundFileButton;
        private System.Windows.Forms.CheckBox useSoundAlertCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label smtpServerLabel;
        private System.Windows.Forms.Label smtpPortLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label fromAddressLabel;
        private System.Windows.Forms.Label toAddressLabel;
        private System.Windows.Forms.Label soundFileLabel;
        private System.Windows.Forms.Button emailtestButton;
        private TextBox textBoxEmailMinuteLimit;
        private Label label1;
        private Label label2;
    }
}
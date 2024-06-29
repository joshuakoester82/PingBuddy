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
            this.smtpServerTextBox = new System.Windows.Forms.TextBox();
            this.smtpPortTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.fromAddressTextBox = new System.Windows.Forms.TextBox();
            this.toAddressTextBox = new System.Windows.Forms.TextBox();
            this.useEmailNotificationCheckBox = new System.Windows.Forms.CheckBox();
            this.soundFilePathTextBox = new System.Windows.Forms.TextBox();
            this.browseSoundFileButton = new System.Windows.Forms.Button();
            this.useSoundAlertCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.smtpServerLabel = new System.Windows.Forms.Label();
            this.smtpPortLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.fromAddressLabel = new System.Windows.Forms.Label();
            this.toAddressLabel = new System.Windows.Forms.Label();
            this.soundFileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // smtpServerTextBox
            // 
            this.smtpServerTextBox.Location = new System.Drawing.Point(130, 50);
            this.smtpServerTextBox.Name = "smtpServerTextBox";
            this.smtpServerTextBox.Size = new System.Drawing.Size(200, 20);
            this.smtpServerTextBox.TabIndex = 1;
            // 
            // smtpPortTextBox
            // 
            this.smtpPortTextBox.Location = new System.Drawing.Point(130, 80);
            this.smtpPortTextBox.Name = "smtpPortTextBox";
            this.smtpPortTextBox.Size = new System.Drawing.Size(200, 20);
            this.smtpPortTextBox.TabIndex = 2;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(130, 110);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(200, 20);
            this.usernameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(130, 140);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(200, 20);
            this.passwordTextBox.TabIndex = 4;
            // 
            // fromAddressTextBox
            // 
            this.fromAddressTextBox.Location = new System.Drawing.Point(130, 170);
            this.fromAddressTextBox.Name = "fromAddressTextBox";
            this.fromAddressTextBox.Size = new System.Drawing.Size(200, 20);
            this.fromAddressTextBox.TabIndex = 5;
            // 
            // toAddressTextBox
            // 
            this.toAddressTextBox.Location = new System.Drawing.Point(130, 200);
            this.toAddressTextBox.Name = "toAddressTextBox";
            this.toAddressTextBox.Size = new System.Drawing.Size(200, 20);
            this.toAddressTextBox.TabIndex = 6;
            // 
            // useEmailNotificationCheckBox
            // 
            this.useEmailNotificationCheckBox.AutoSize = true;
            this.useEmailNotificationCheckBox.Location = new System.Drawing.Point(20, 20);
            this.useEmailNotificationCheckBox.Name = "useEmailNotificationCheckBox";
            this.useEmailNotificationCheckBox.Size = new System.Drawing.Size(136, 17);
            this.useEmailNotificationCheckBox.TabIndex = 0;
            this.useEmailNotificationCheckBox.Text = "Use Email Notification";
            this.useEmailNotificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // soundFilePathTextBox
            // 
            this.soundFilePathTextBox.Location = new System.Drawing.Point(130, 270);
            this.soundFilePathTextBox.Name = "soundFilePathTextBox";
            this.soundFilePathTextBox.Size = new System.Drawing.Size(200, 20);
            this.soundFilePathTextBox.TabIndex = 8;
            // 
            // browseSoundFileButton
            // 
            this.browseSoundFileButton.Location = new System.Drawing.Point(340, 268);
            this.browseSoundFileButton.Name = "browseSoundFileButton";
            this.browseSoundFileButton.Size = new System.Drawing.Size(75, 23);
            this.browseSoundFileButton.TabIndex = 9;
            this.browseSoundFileButton.Text = "Browse";
            this.browseSoundFileButton.UseVisualStyleBackColor = true;
            this.browseSoundFileButton.Click += new System.EventHandler(this.BrowseSoundFileButton_Click);
            // 
            // useSoundAlertCheckBox
            // 
            this.useSoundAlertCheckBox.AutoSize = true;
            this.useSoundAlertCheckBox.Location = new System.Drawing.Point(20, 240);
            this.useSoundAlertCheckBox.Name = "useSoundAlertCheckBox";
            this.useSoundAlertCheckBox.Size = new System.Drawing.Size(104, 17);
            this.useSoundAlertCheckBox.TabIndex = 7;
            this.useSoundAlertCheckBox.Text = "Use Sound Alert";
            this.useSoundAlertCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(130, 310);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(220, 310);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // smtpServerLabel
            // 
            this.smtpServerLabel.AutoSize = true;
            this.smtpServerLabel.Location = new System.Drawing.Point(20, 53);
            this.smtpServerLabel.Name = "smtpServerLabel";
            this.smtpServerLabel.Size = new System.Drawing.Size(71, 13);
            this.smtpServerLabel.TabIndex = 12;
            this.smtpServerLabel.Text = "SMTP Server:";
            // 
            // smtpPortLabel
            // 
            this.smtpPortLabel.AutoSize = true;
            this.smtpPortLabel.Location = new System.Drawing.Point(20, 83);
            this.smtpPortLabel.Name = "smtpPortLabel";
            this.smtpPortLabel.Size = new System.Drawing.Size(60, 13);
            this.smtpPortLabel.TabIndex = 13;
            this.smtpPortLabel.Text = "SMTP Port:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(20, 113);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 14;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(20, 143);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 15;
            this.passwordLabel.Text = "Password:";
            // 
            // fromAddressLabel
            // 
            this.fromAddressLabel.AutoSize = true;
            this.fromAddressLabel.Location = new System.Drawing.Point(20, 173);
            this.fromAddressLabel.Name = "fromAddressLabel";
            this.fromAddressLabel.Size = new System.Drawing.Size(74, 13);
            this.fromAddressLabel.TabIndex = 16;
            this.fromAddressLabel.Text = "From Address:";
            // 
            // toAddressLabel
            // 
            this.toAddressLabel.AutoSize = true;
            this.toAddressLabel.Location = new System.Drawing.Point(20, 203);
            this.toAddressLabel.Name = "toAddressLabel";
            this.toAddressLabel.Size = new System.Drawing.Size(64, 13);
            this.toAddressLabel.TabIndex = 17;
            this.toAddressLabel.Text = "To Address:";
            // 
            // soundFileLabel
            // 
            this.soundFileLabel.AutoSize = true;
            this.soundFileLabel.Location = new System.Drawing.Point(20, 273);
            this.soundFileLabel.Name = "soundFileLabel";
            this.soundFileLabel.Size = new System.Drawing.Size(61, 13);
            this.soundFileLabel.TabIndex = 18;
            this.soundFileLabel.Text = "Sound File:";
            // 
            // NotificationSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 361);
            this.Controls.Add(this.soundFileLabel);
            this.Controls.Add(this.toAddressLabel);
            this.Controls.Add(this.fromAddressLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.smtpPortLabel);
            this.Controls.Add(this.smtpServerLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.useSoundAlertCheckBox);
            this.Controls.Add(this.browseSoundFileButton);
            this.Controls.Add(this.soundFilePathTextBox);
            this.Controls.Add(this.useEmailNotificationCheckBox);
            this.Controls.Add(this.toAddressTextBox);
            this.Controls.Add(this.fromAddressTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.smtpPortTextBox);
            this.Controls.Add(this.smtpServerTextBox);
            this.Name = "NotificationSettingsForm";
            this.Text = "Notification Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
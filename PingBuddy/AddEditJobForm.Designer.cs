namespace PingBuddy
{
    partial class AddEditJobForm
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
            nameTextBox = new TextBox();
            hostTextBox = new TextBox();
            intervalNumericUpDown = new NumericUpDown();
            timeoutNumericUpDown = new NumericUpDown();
            bufferSizeNumericUpDown = new NumericUpDown();
            latencyThresholdNumericUpDown = new NumericUpDown();
            packetLossThresholdNumericUpDown = new NumericUpDown();
            consecutiveFailuresNumericUpDown = new NumericUpDown();
            playSoundCheckBox = new CheckBox();
            sendEmailCheckBox = new CheckBox();
            saveButton = new Button();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)intervalNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeoutNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bufferSizeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)latencyThresholdNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)packetLossThresholdNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)consecutiveFailuresNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(0, 0);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(100, 31);
            nameTextBox.TabIndex = 0;
            // 
            // hostTextBox
            // 
            hostTextBox.Location = new Point(0, 0);
            hostTextBox.Name = "hostTextBox";
            hostTextBox.Size = new Size(100, 31);
            hostTextBox.TabIndex = 0;
            // 
            // intervalNumericUpDown
            // 
            intervalNumericUpDown.Location = new Point(0, 0);
            intervalNumericUpDown.Name = "intervalNumericUpDown";
            intervalNumericUpDown.Size = new Size(120, 31);
            intervalNumericUpDown.TabIndex = 0;
            // 
            // timeoutNumericUpDown
            // 
            timeoutNumericUpDown.Location = new Point(0, 0);
            timeoutNumericUpDown.Name = "timeoutNumericUpDown";
            timeoutNumericUpDown.Size = new Size(120, 31);
            timeoutNumericUpDown.TabIndex = 0;
            // 
            // bufferSizeNumericUpDown
            // 
            bufferSizeNumericUpDown.Location = new Point(0, 0);
            bufferSizeNumericUpDown.Name = "bufferSizeNumericUpDown";
            bufferSizeNumericUpDown.Size = new Size(120, 31);
            bufferSizeNumericUpDown.TabIndex = 0;
            // 
            // latencyThresholdNumericUpDown
            // 
            latencyThresholdNumericUpDown.Location = new Point(0, 0);
            latencyThresholdNumericUpDown.Name = "latencyThresholdNumericUpDown";
            latencyThresholdNumericUpDown.Size = new Size(120, 31);
            latencyThresholdNumericUpDown.TabIndex = 0;
            // 
            // packetLossThresholdNumericUpDown
            // 
            packetLossThresholdNumericUpDown.Location = new Point(0, 0);
            packetLossThresholdNumericUpDown.Name = "packetLossThresholdNumericUpDown";
            packetLossThresholdNumericUpDown.Size = new Size(120, 31);
            packetLossThresholdNumericUpDown.TabIndex = 0;
            // 
            // consecutiveFailuresNumericUpDown
            // 
            consecutiveFailuresNumericUpDown.Location = new Point(0, 0);
            consecutiveFailuresNumericUpDown.Name = "consecutiveFailuresNumericUpDown";
            consecutiveFailuresNumericUpDown.Size = new Size(120, 31);
            consecutiveFailuresNumericUpDown.TabIndex = 0;
            // 
            // playSoundCheckBox
            // 
            playSoundCheckBox.Location = new Point(0, 0);
            playSoundCheckBox.Name = "playSoundCheckBox";
            playSoundCheckBox.Size = new Size(104, 24);
            playSoundCheckBox.TabIndex = 0;
            // 
            // sendEmailCheckBox
            // 
            sendEmailCheckBox.Location = new Point(0, 0);
            sendEmailCheckBox.Name = "sendEmailCheckBox";
            sendEmailCheckBox.Size = new Size(104, 24);
            sendEmailCheckBox.TabIndex = 0;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(150, 520);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 30);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(270, 520);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 30);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.Click += CancelButton_Click;
            // 
            // AddEditJobForm
            // 
            AcceptButton = saveButton;
            CancelButton = cancelButton;
            ClientSize = new Size(458, 604);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditJobForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add/Edit Ping Job";
            ((System.ComponentModel.ISupportInitialize)intervalNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeoutNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)bufferSizeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)latencyThresholdNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)packetLossThresholdNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)consecutiveFailuresNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox CreateTextBox(int y, string labelText)
        {
            var label = new System.Windows.Forms.Label
            {
                Text = labelText,
                Location = new System.Drawing.Point(30, y),
                Size = new System.Drawing.Size(150, 20),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            this.Controls.Add(label);

            var textBox = new System.Windows.Forms.TextBox
            {
                Location = new System.Drawing.Point(200, y),
                Size = new System.Drawing.Size(250, 20)
            };
            this.Controls.Add(textBox);

            return textBox;
        }

        private System.Windows.Forms.NumericUpDown CreateNumericUpDown(int y, string labelText)
        {
            var label = new System.Windows.Forms.Label
            {
                Text = labelText,
                Location = new System.Drawing.Point(30, y),
                Size = new System.Drawing.Size(150, 20),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            this.Controls.Add(label);

            var numericUpDown = new System.Windows.Forms.NumericUpDown
            {
                Location = new System.Drawing.Point(200, y),
                Size = new System.Drawing.Size(250, 20)
            };
            this.Controls.Add(numericUpDown);

            return numericUpDown;
        }

        private System.Windows.Forms.CheckBox CreateCheckBox(int y, string text)
        {
            var checkBox = new System.Windows.Forms.CheckBox
            {
                Text = text,
                Location = new System.Drawing.Point(30, y),
                Size = new System.Drawing.Size(400, 24)
            };
            this.Controls.Add(checkBox);

            return checkBox;
        }

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.NumericUpDown intervalNumericUpDown;
        private System.Windows.Forms.NumericUpDown timeoutNumericUpDown;
        private System.Windows.Forms.NumericUpDown bufferSizeNumericUpDown;
        private System.Windows.Forms.NumericUpDown latencyThresholdNumericUpDown;
        private System.Windows.Forms.NumericUpDown packetLossThresholdNumericUpDown;
        private System.Windows.Forms.NumericUpDown consecutiveFailuresNumericUpDown;
        private System.Windows.Forms.CheckBox playSoundCheckBox;
        private System.Windows.Forms.CheckBox sendEmailCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

        #endregion
    }
}
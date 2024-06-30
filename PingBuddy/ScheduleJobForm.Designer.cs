namespace PingBuddy
{
    partial class ScheduleJobForm
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
            jobListBox = new ListBox();
            startDateTimePicker = new DateTimePicker();
            durationNumericUpDown = new NumericUpDown();
            scheduleButton = new Button();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)durationNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // jobListBox
            // 
            jobListBox.FormattingEnabled = true;
            jobListBox.ItemHeight = 25;
            jobListBox.Location = new Point(12, 12);
            jobListBox.Name = "jobListBox";
            jobListBox.Size = new Size(640, 479);
            jobListBox.TabIndex = 0;
            // 
            // startDateTimePicker
            // 
            startDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            startDateTimePicker.Format = DateTimePickerFormat.Custom;
            startDateTimePicker.Location = new Point(12, 521);
            startDateTimePicker.Name = "startDateTimePicker";
            startDateTimePicker.Size = new Size(343, 31);
            startDateTimePicker.TabIndex = 1;
            // 
            // durationNumericUpDown
            // 
            durationNumericUpDown.Location = new Point(12, 558);
            durationNumericUpDown.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            durationNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            durationNumericUpDown.Name = "durationNumericUpDown";
            durationNumericUpDown.Size = new Size(343, 31);
            durationNumericUpDown.TabIndex = 2;
            durationNumericUpDown.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // scheduleButton
            // 
            scheduleButton.Location = new Point(12, 683);
            scheduleButton.Name = "scheduleButton";
            scheduleButton.Size = new Size(162, 43);
            scheduleButton.TabIndex = 3;
            scheduleButton.Text = "Schedule";
            scheduleButton.UseVisualStyleBackColor = true;
            scheduleButton.Click += ScheduleButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(193, 683);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(162, 43);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // ScheduleJobForm
            // 
            ClientSize = new Size(680, 753);
            Controls.Add(jobListBox);
            Controls.Add(startDateTimePicker);
            Controls.Add(durationNumericUpDown);
            Controls.Add(scheduleButton);
            Controls.Add(cancelButton);
            Name = "ScheduleJobForm";
            Text = "Schedule Jobs";
            ((System.ComponentModel.ISupportInitialize)durationNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox jobListBox;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.NumericUpDown durationNumericUpDown;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
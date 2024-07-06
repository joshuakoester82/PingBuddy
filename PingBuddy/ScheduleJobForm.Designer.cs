namespace PingBuddy
{
    partial class ScheduleJobForm
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            availableJobsListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            scheduledJobsListView = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            startDateTimePicker = new DateTimePicker();
            durationNumericUpDown = new NumericUpDown();
            scheduleButton = new Button();
            removeScheduledJobButton = new Button();
            outputFolderTextBox = new TextBox();
            selectOutputFolderButton = new Button();
            saveButton = new Button();
            cancelButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)durationNumericUpDown).BeginInit();
            SuspendLayout();
            //
            // autoExportCheckbox
            //
            autoExportCheckBox = new CheckBox();
            autoExportCheckBox.AutoSize = true;
            autoExportCheckBox.Location = new Point(17, 810);
            autoExportCheckBox.Name = "autoExportCheckBox";
            autoExportCheckBox.Size = new Size(250, 29);
            autoExportCheckBox.TabIndex = 15;
            autoExportCheckBox.Text = "Automatically export when job completes";
            autoExportCheckBox.UseVisualStyleBackColor = true;
            // 
            // availableJobsListView
            // 
            availableJobsListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            availableJobsListView.FullRowSelect = true;
            availableJobsListView.Location = new Point(17, 53);
            availableJobsListView.Margin = new Padding(4, 5, 4, 5);
            availableJobsListView.Name = "availableJobsListView";
            availableJobsListView.Size = new Size(446, 577);
            availableJobsListView.TabIndex = 0;
            availableJobsListView.UseCompatibleStateImageBehavior = false;
            availableJobsListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Host";
            columnHeader2.Width = 150;
            // 
            // scheduledJobsListView
            // 
            scheduledJobsListView.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            scheduledJobsListView.FullRowSelect = true;
            scheduledJobsListView.Location = new Point(480, 52);
            scheduledJobsListView.Margin = new Padding(4, 5, 4, 5);
            scheduledJobsListView.Name = "scheduledJobsListView";
            scheduledJobsListView.Size = new Size(967, 578);
            scheduledJobsListView.TabIndex = 1;
            scheduledJobsListView.UseCompatibleStateImageBehavior = false;
            scheduledJobsListView.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Name";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Start Time";
            columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Duration";
            columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Status";
            columnHeader6.Width = 80;
            // 
            // startDateTimePicker
            // 
            startDateTimePicker.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            startDateTimePicker.Format = DateTimePickerFormat.Custom;
            startDateTimePicker.Location = new Point(17, 687);
            startDateTimePicker.Margin = new Padding(4, 5, 4, 5);
            startDateTimePicker.Name = "startDateTimePicker";
            startDateTimePicker.Size = new Size(284, 31);
            startDateTimePicker.TabIndex = 2;
            // 
            // durationNumericUpDown
            // 
            durationNumericUpDown.Location = new Point(317, 687);
            durationNumericUpDown.Margin = new Padding(4, 5, 4, 5);
            durationNumericUpDown.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            durationNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            durationNumericUpDown.Name = "durationNumericUpDown";
            durationNumericUpDown.Size = new Size(129, 31);
            durationNumericUpDown.TabIndex = 3;
            durationNumericUpDown.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // scheduleButton
            // 
            scheduleButton.Location = new Point(460, 687);
            scheduleButton.Margin = new Padding(4, 5, 4, 5);
            scheduleButton.Name = "scheduleButton";
            scheduleButton.Size = new Size(107, 38);
            scheduleButton.TabIndex = 4;
            scheduleButton.Text = "Schedule";
            scheduleButton.UseVisualStyleBackColor = true;
            // 
            // removeScheduledJobButton
            // 
            removeScheduledJobButton.Location = new Point(588, 687);
            removeScheduledJobButton.Margin = new Padding(4, 5, 4, 5);
            removeScheduledJobButton.Name = "removeScheduledJobButton";
            removeScheduledJobButton.Size = new Size(107, 38);
            removeScheduledJobButton.TabIndex = 5;
            removeScheduledJobButton.Text = "Remove";
            removeScheduledJobButton.UseVisualStyleBackColor = true;
            // 
            // outputFolderTextBox
            // 
            outputFolderTextBox.Location = new Point(17, 770);
            outputFolderTextBox.Margin = new Padding(4, 5, 4, 5);
            outputFolderTextBox.Name = "outputFolderTextBox";
            outputFolderTextBox.Size = new Size(427, 31);
            outputFolderTextBox.TabIndex = 6;
            // 
            // selectOutputFolderButton
            // 
            selectOutputFolderButton.Location = new Point(460, 770);
            selectOutputFolderButton.Margin = new Padding(4, 5, 4, 5);
            selectOutputFolderButton.Name = "selectOutputFolderButton";
            selectOutputFolderButton.Size = new Size(107, 38);
            selectOutputFolderButton.TabIndex = 7;
            selectOutputFolderButton.Text = "Browse";
            selectOutputFolderButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(1224, 770);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(107, 38);
            saveButton.TabIndex = 8;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(1340, 770);
            cancelButton.Margin = new Padding(4, 5, 4, 5);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(107, 38);
            cancelButton.TabIndex = 9;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 22);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 10;
            label1.Text = "Available Jobs:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(480, 22);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(139, 25);
            label2.TabIndex = 11;
            label2.Text = "Scheduled Jobs:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 657);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(95, 25);
            label3.TabIndex = 12;
            label3.Text = "Start Time:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(317, 657);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(138, 25);
            label4.TabIndex = 13;
            label4.Text = "Duration (mins):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 740);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(128, 25);
            label5.TabIndex = 14;
            label5.Text = "Output Folder:";
            // 
            // ScheduleJobForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1475, 852);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(selectOutputFolderButton);
            Controls.Add(outputFolderTextBox);
            Controls.Add(removeScheduledJobButton);
            Controls.Add(scheduleButton);
            Controls.Add(durationNumericUpDown);
            Controls.Add(startDateTimePicker);
            Controls.Add(scheduledJobsListView);
            Controls.Add(availableJobsListView);
            Controls.Add(autoExportCheckBox);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ScheduleJobForm";
            Text = "Schedule Jobs";
            ((System.ComponentModel.ISupportInitialize)durationNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView availableJobsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView scheduledJobsListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.NumericUpDown durationNumericUpDown;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.Button removeScheduledJobButton;
        private System.Windows.Forms.TextBox outputFolderTextBox;
        private System.Windows.Forms.Button selectOutputFolderButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox autoExportCheckBox;
    }
}

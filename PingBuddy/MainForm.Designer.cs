namespace PingBuddy
{
    partial class MainForm
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
            menuStrip = new MenuStrip();
            helpMenu = new ToolStripMenuItem();
            jobList = new ListBox();
            resultList = new ListBox();
            alertList = new ListBox();
            curJobPingList = new ListBox();
            addJobButton = new Button();
            editJobButton = new Button();
            removeJobButton = new Button();
            viewChartButton = new Button();
            exportSettingsButton = new Button();
            importSettingsButton = new Button();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            startAllJobsButton = new Button();
            stopAllJobsButton = new Button();
            clearResultsButton = new Button();
            clearAlertsButton = new Button();
            jobListHeaderLabel = new Label();
            curJobPingListHeaderLabel = new Label();
            resultListHeaderLabel = new Label();
            alertListHeaderLabel = new Label();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { helpMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(10, 4, 0, 4);
            menuStrip.Size = new Size(1898, 37);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // helpMenu
            // 
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(65, 29);
            helpMenu.Text = "Help";
            // 
            // jobList
            // 
            jobList.FormattingEnabled = true;
            jobList.ItemHeight = 25;
            jobList.Location = new Point(20, 88);
            jobList.Margin = new Padding(5, 6, 5, 6);
            jobList.Name = "jobList";
            jobList.Size = new Size(259, 704);
            jobList.TabIndex = 1;
            // 
            // resultList
            // 
            resultList.FormattingEnabled = true;
            resultList.ItemHeight = 25;
            resultList.Location = new Point(801, 88);
            resultList.Margin = new Padding(5, 6, 5, 6);
            resultList.Name = "resultList";
            resultList.Size = new Size(500, 704);
            resultList.TabIndex = 3;
            // 
            // alertList
            // 
            alertList.FormattingEnabled = true;
            alertList.ItemHeight = 25;
            alertList.Location = new Point(1311, 88);
            alertList.Margin = new Padding(5, 6, 5, 6);
            alertList.Name = "alertList";
            alertList.Size = new Size(500, 704);
            alertList.TabIndex = 4;
            // 
            // curJobPingList
            // 
            curJobPingList.FormattingEnabled = true;
            curJobPingList.ItemHeight = 25;
            curJobPingList.Location = new Point(289, 88);
            curJobPingList.Margin = new Padding(5, 6, 5, 6);
            curJobPingList.Name = "curJobPingList";
            curJobPingList.Size = new Size(500, 704);
            curJobPingList.TabIndex = 2;
            // 
            // addJobButton
            // 
            addJobButton.Location = new Point(23, 821);
            addJobButton.Margin = new Padding(5, 6, 5, 6);
            addJobButton.Name = "addJobButton";
            addJobButton.Size = new Size(167, 58);
            addJobButton.TabIndex = 5;
            addJobButton.Text = "Add Job";
            addJobButton.UseVisualStyleBackColor = true;
            // 
            // editJobButton
            // 
            editJobButton.Location = new Point(23, 890);
            editJobButton.Margin = new Padding(5, 6, 5, 6);
            editJobButton.Name = "editJobButton";
            editJobButton.Size = new Size(167, 58);
            editJobButton.TabIndex = 6;
            editJobButton.Text = "Edit Job";
            editJobButton.UseVisualStyleBackColor = true;
            // 
            // removeJobButton
            // 
            removeJobButton.Location = new Point(23, 960);
            removeJobButton.Margin = new Padding(5, 6, 5, 6);
            removeJobButton.Name = "removeJobButton";
            removeJobButton.Size = new Size(167, 58);
            removeJobButton.TabIndex = 7;
            removeJobButton.Text = "Remove Job";
            removeJobButton.UseVisualStyleBackColor = true;
            // 
            // viewChartButton
            // 
            viewChartButton.Location = new Point(233, 960);
            viewChartButton.Margin = new Padding(5, 6, 5, 6);
            viewChartButton.Name = "viewChartButton";
            viewChartButton.Size = new Size(200, 58);
            viewChartButton.TabIndex = 8;
            viewChartButton.Text = "View Chart";
            viewChartButton.UseVisualStyleBackColor = true;
            // 
            // exportSettingsButton
            // 
            exportSettingsButton.Location = new Point(233, 1040);
            exportSettingsButton.Margin = new Padding(5, 6, 5, 6);
            exportSettingsButton.Name = "exportSettingsButton";
            exportSettingsButton.Size = new Size(200, 58);
            exportSettingsButton.TabIndex = 9;
            exportSettingsButton.Text = "Export Settings";
            exportSettingsButton.UseVisualStyleBackColor = true;
            // 
            // importSettingsButton
            // 
            importSettingsButton.Location = new Point(23, 1040);
            importSettingsButton.Margin = new Padding(5, 6, 5, 6);
            importSettingsButton.Name = "importSettingsButton";
            importSettingsButton.Size = new Size(200, 58);
            importSettingsButton.TabIndex = 10;
            importSettingsButton.Text = "Import Settings";
            importSettingsButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 1121);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(2, 0, 23, 0);
            statusStrip.Size = new Size(1898, 32);
            statusStrip.TabIndex = 11;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(60, 25);
            statusLabel.Text = "Ready";
            // 
            // startAllJobsButton
            // 
            startAllJobsButton.Location = new Point(1678, 821);
            startAllJobsButton.Margin = new Padding(5, 6, 5, 6);
            startAllJobsButton.Name = "startAllJobsButton";
            startAllJobsButton.Size = new Size(200, 113);
            startAllJobsButton.TabIndex = 16;
            startAllJobsButton.Text = "Start All Jobs";
            startAllJobsButton.UseVisualStyleBackColor = true;
            // 
            // stopAllJobsButton
            // 
            stopAllJobsButton.Location = new Point(1678, 946);
            stopAllJobsButton.Margin = new Padding(5, 6, 5, 6);
            stopAllJobsButton.Name = "stopAllJobsButton";
            stopAllJobsButton.Size = new Size(200, 113);
            stopAllJobsButton.TabIndex = 17;
            stopAllJobsButton.Text = "Stop All Jobs";
            stopAllJobsButton.UseVisualStyleBackColor = true;
            // 
            // clearResultsButton
            // 
            clearResultsButton.Location = new Point(233, 821);
            clearResultsButton.Margin = new Padding(5, 6, 5, 6);
            clearResultsButton.Name = "clearResultsButton";
            clearResultsButton.Size = new Size(200, 58);
            clearResultsButton.TabIndex = 18;
            clearResultsButton.Text = "Clear Results";
            clearResultsButton.UseVisualStyleBackColor = true;
            // 
            // clearAlertsButton
            // 
            clearAlertsButton.Location = new Point(233, 890);
            clearAlertsButton.Margin = new Padding(5, 6, 5, 6);
            clearAlertsButton.Name = "clearAlertsButton";
            clearAlertsButton.Size = new Size(200, 58);
            clearAlertsButton.TabIndex = 19;
            clearAlertsButton.Text = "Clear Alerts";
            clearAlertsButton.UseVisualStyleBackColor = true;
            // 
            // jobListHeaderLabel
            // 
            jobListHeaderLabel.AutoSize = true;
            jobListHeaderLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jobListHeaderLabel.Location = new Point(20, 51);
            jobListHeaderLabel.Margin = new Padding(5, 0, 5, 0);
            jobListHeaderLabel.Name = "jobListHeaderLabel";
            jobListHeaderLabel.Size = new Size(129, 29);
            jobListHeaderLabel.TabIndex = 12;
            jobListHeaderLabel.Text = "Ping Jobs";
            // 
            // curJobPingListHeaderLabel
            // 
            curJobPingListHeaderLabel.AutoSize = true;
            curJobPingListHeaderLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            curJobPingListHeaderLabel.Location = new Point(289, 53);
            curJobPingListHeaderLabel.Margin = new Padding(5, 0, 5, 0);
            curJobPingListHeaderLabel.Name = "curJobPingListHeaderLabel";
            curJobPingListHeaderLabel.Size = new Size(228, 29);
            curJobPingListHeaderLabel.TabIndex = 13;
            curJobPingListHeaderLabel.Text = "Current Job Status";
            // 
            // resultListHeaderLabel
            // 
            resultListHeaderLabel.AutoSize = true;
            resultListHeaderLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            resultListHeaderLabel.Location = new Point(801, 53);
            resultListHeaderLabel.Margin = new Padding(5, 0, 5, 0);
            resultListHeaderLabel.Name = "resultListHeaderLabel";
            resultListHeaderLabel.Size = new Size(160, 29);
            resultListHeaderLabel.TabIndex = 14;
            resultListHeaderLabel.Text = "Ping Results";
            // 
            // alertListHeaderLabel
            // 
            alertListHeaderLabel.AutoSize = true;
            alertListHeaderLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            alertListHeaderLabel.Location = new Point(1311, 53);
            alertListHeaderLabel.Margin = new Padding(5, 0, 5, 0);
            alertListHeaderLabel.Name = "alertListHeaderLabel";
            alertListHeaderLabel.Size = new Size(80, 29);
            alertListHeaderLabel.TabIndex = 15;
            alertListHeaderLabel.Text = "Alerts";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1153);
            Controls.Add(clearAlertsButton);
            Controls.Add(clearResultsButton);
            Controls.Add(stopAllJobsButton);
            Controls.Add(startAllJobsButton);
            Controls.Add(alertListHeaderLabel);
            Controls.Add(resultListHeaderLabel);
            Controls.Add(curJobPingListHeaderLabel);
            Controls.Add(jobListHeaderLabel);
            Controls.Add(statusStrip);
            Controls.Add(importSettingsButton);
            Controls.Add(exportSettingsButton);
            Controls.Add(viewChartButton);
            Controls.Add(removeJobButton);
            Controls.Add(editJobButton);
            Controls.Add(addJobButton);
            Controls.Add(alertList);
            Controls.Add(resultList);
            Controls.Add(curJobPingList);
            Controls.Add(jobList);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(5, 6, 5, 6);
            Name = "MainForm";
            Text = "Ping Buddy";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        //private System.Windows.Forms.ToolStripMenuItem settingsMenu; // Possibly remove, possible duplicate.
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ListBox jobList;
        private System.Windows.Forms.ListBox resultList;
        private System.Windows.Forms.ListBox alertList;
        private System.Windows.Forms.ListBox curJobPingList;
        private System.Windows.Forms.Button addJobButton;
        private System.Windows.Forms.Button editJobButton;
        private System.Windows.Forms.Button removeJobButton;
        private System.Windows.Forms.Button viewChartButton;
        private System.Windows.Forms.Button exportSettingsButton;
        private System.Windows.Forms.Button importSettingsButton;
        private System.Windows.Forms.Button clearAlertsButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button startAllJobsButton;
        private System.Windows.Forms.Button stopAllJobsButton;
        private System.Windows.Forms.Button clearResultsButton;
        private System.Windows.Forms.Label jobListHeaderLabel;
        private System.Windows.Forms.Label curJobPingListHeaderLabel;
        private System.Windows.Forms.Label resultListHeaderLabel;
        private System.Windows.Forms.Label alertListHeaderLabel;
        
    }
}
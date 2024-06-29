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
            settingsMenu = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            jobList = new ListBox();
            curJobPingList = new ListBox();
            resultList = new ListBox();
            alertList = new ListBox();
            addJobButton = new Button();
            editJobButton = new Button();
            removeJobButton = new Button();
            viewChartButton = new Button();
            exportSettingsButton = new Button();
            importSettingsButton = new Button();
            startAllJobsButton = new Button();
            stopAllJobsButton = new Button();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { settingsMenu, helpMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(10, 4, 0, 4);
            menuStrip.Size = new Size(1898, 37);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // settingsMenu
            // 
            settingsMenu.Name = "settingsMenu";
            settingsMenu.Size = new Size(92, 29);
            settingsMenu.Text = "Settings";
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
            jobList.Location = new Point(20, 52);
            jobList.Margin = new Padding(5, 6, 5, 6);
            jobList.Name = "jobList";
            jobList.Size = new Size(331, 754);
            jobList.TabIndex = 1;
            // 
            // curJobPingList
            // 
            curJobPingList.FormattingEnabled = true;
            curJobPingList.ItemHeight = 25;
            curJobPingList.Location = new Point(367, 52);
            curJobPingList.Margin = new Padding(5, 6, 5, 6);
            curJobPingList.Name = "curJobPingList";
            curJobPingList.Size = new Size(472, 754);
            curJobPingList.TabIndex = 2;
            // 
            // resultList
            // 
            resultList.FormattingEnabled = true;
            resultList.ItemHeight = 25;
            resultList.Location = new Point(861, 52);
            resultList.Margin = new Padding(5, 6, 5, 6);
            resultList.Name = "resultList";
            resultList.Size = new Size(497, 754);
            resultList.TabIndex = 3;
            // 
            // alertList
            // 
            alertList.FormattingEnabled = true;
            alertList.ItemHeight = 25;
            alertList.Location = new Point(1381, 52);
            alertList.Margin = new Padding(5, 6, 5, 6);
            alertList.Name = "alertList";
            alertList.Size = new Size(484, 754);
            alertList.TabIndex = 4;
            // 
            // addJobButton
            // 
            addJobButton.Location = new Point(20, 846);
            addJobButton.Margin = new Padding(5, 6, 5, 6);
            addJobButton.Name = "addJobButton";
            addJobButton.Size = new Size(125, 44);
            addJobButton.TabIndex = 5;
            addJobButton.Text = "Add Job";
            addJobButton.UseVisualStyleBackColor = true;
            // 
            // editJobButton
            // 
            editJobButton.Location = new Point(20, 904);
            editJobButton.Margin = new Padding(5, 6, 5, 6);
            editJobButton.Name = "editJobButton";
            editJobButton.Size = new Size(125, 44);
            editJobButton.TabIndex = 6;
            editJobButton.Text = "Edit Job";
            editJobButton.UseVisualStyleBackColor = true;
            // 
            // removeJobButton
            // 
            removeJobButton.Location = new Point(20, 962);
            removeJobButton.Margin = new Padding(5, 6, 5, 6);
            removeJobButton.Name = "removeJobButton";
            removeJobButton.Size = new Size(125, 44);
            removeJobButton.TabIndex = 7;
            removeJobButton.Text = "Remove Job";
            removeJobButton.UseVisualStyleBackColor = true;
            // 
            // viewChartButton
            // 
            viewChartButton.Location = new Point(714, 846);
            viewChartButton.Margin = new Padding(5, 6, 5, 6);
            viewChartButton.Name = "viewChartButton";
            viewChartButton.Size = new Size(125, 44);
            viewChartButton.TabIndex = 8;
            viewChartButton.Text = "View Chart";
            viewChartButton.UseVisualStyleBackColor = true;
            // 
            // exportSettingsButton
            // 
            exportSettingsButton.Location = new Point(20, 1019);
            exportSettingsButton.Margin = new Padding(5, 6, 5, 6);
            exportSettingsButton.Name = "exportSettingsButton";
            exportSettingsButton.Size = new Size(167, 44);
            exportSettingsButton.TabIndex = 9;
            exportSettingsButton.Text = "Export Settings";
            exportSettingsButton.UseVisualStyleBackColor = true;
            // 
            // importSettingsButton
            // 
            importSettingsButton.Location = new Point(217, 1019);
            importSettingsButton.Margin = new Padding(5, 6, 5, 6);
            importSettingsButton.Name = "importSettingsButton";
            importSettingsButton.Size = new Size(167, 44);
            importSettingsButton.TabIndex = 10;
            importSettingsButton.Text = "Import Settings";
            importSettingsButton.UseVisualStyleBackColor = true;
            // 
            // startAllJobsButton
            // 
            startAllJobsButton.Location = new Point(367, 846);
            startAllJobsButton.Margin = new Padding(5, 6, 5, 6);
            startAllJobsButton.Name = "startAllJobsButton";
            startAllJobsButton.Size = new Size(167, 44);
            startAllJobsButton.TabIndex = 11;
            startAllJobsButton.Text = "Start All Jobs";
            startAllJobsButton.UseVisualStyleBackColor = true;
            // 
            // stopAllJobsButton
            // 
            stopAllJobsButton.Location = new Point(367, 904);
            stopAllJobsButton.Margin = new Padding(5, 6, 5, 6);
            stopAllJobsButton.Name = "stopAllJobsButton";
            stopAllJobsButton.Size = new Size(167, 44);
            stopAllJobsButton.TabIndex = 12;
            stopAllJobsButton.Text = "Stop All Jobs";
            stopAllJobsButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 1122);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(2, 0, 23, 0);
            statusStrip.Size = new Size(1898, 32);
            statusStrip.TabIndex = 13;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(60, 25);
            statusLabel.Text = "Ready";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1154);
            Controls.Add(statusStrip);
            Controls.Add(stopAllJobsButton);
            Controls.Add(startAllJobsButton);
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

        private MenuStrip menuStrip;
        private ToolStripMenuItem settingsMenu;
        private ToolStripMenuItem helpMenu;
        private ListBox jobList;
        private ListBox curJobPingList;
        private ListBox resultList;
        private ListBox alertList;
        private Button addJobButton;
        private Button editJobButton;
        private Button removeJobButton;
        private Button viewChartButton;
        private Button exportSettingsButton;
        private Button importSettingsButton;
        private Button startAllJobsButton;
        private Button stopAllJobsButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
    }
}
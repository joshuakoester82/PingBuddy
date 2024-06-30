namespace PingBuddy
{
    partial class VisualizationForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.jobListBox = new System.Windows.Forms.ListBox();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.updateButton = new System.Windows.Forms.Button();
            this.latencyCheckBox = new System.Windows.Forms.CheckBox();
            this.packetLossCheckBox = new System.Windows.Forms.CheckBox();
            this.exportDataButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pingChart)).BeginInit();
            this.SuspendLayout();
            // 
            // jobListBox
            // 
            this.jobListBox.FormattingEnabled = true;
            this.jobListBox.Location = new System.Drawing.Point(12, 25);
            this.jobListBox.Name = "jobListBox";
            this.jobListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.jobListBox.Size = new System.Drawing.Size(200, 368);
            this.jobListBox.TabIndex = 0;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(230, 25);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(200, 20);
            this.startDatePicker.TabIndex = 1;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(230, 64);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 20);
            this.endDatePicker.TabIndex = 2;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(230, 90);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(200, 23);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Update Chart";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // latencyCheckBox
            // 
            this.latencyCheckBox.AutoSize = true;
            this.latencyCheckBox.Checked = true;
            this.latencyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.latencyCheckBox.Location = new System.Drawing.Point(230, 493);
            this.latencyCheckBox.Name = "latencyCheckBox";
            this.latencyCheckBox.Size = new System.Drawing.Size(94, 17);
            this.latencyCheckBox.TabIndex = 5;
            this.latencyCheckBox.Text = "Show Latency";
            this.latencyCheckBox.UseVisualStyleBackColor = true;
            // 
            // packetLossCheckBox
            // 
            this.packetLossCheckBox.AutoSize = true;
            this.packetLossCheckBox.Location = new System.Drawing.Point(330, 493);
            this.packetLossCheckBox.Name = "packetLossCheckBox";
            this.packetLossCheckBox.Size = new System.Drawing.Size(117, 17);
            this.packetLossCheckBox.TabIndex = 6;
            this.packetLossCheckBox.Text = "Show Packet Loss";
            this.packetLossCheckBox.UseVisualStyleBackColor = true;
            // 
            // exportDataButton
            // 
            this.exportDataButton.Location = new System.Drawing.Point(688, 493);
            this.exportDataButton.Name = "exportDataButton";
            this.exportDataButton.Size = new System.Drawing.Size(100, 23);
            this.exportDataButton.TabIndex = 7;
            this.exportDataButton.Text = "Export Data";
            this.exportDataButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select Job:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "End Date:";
            // 
            // pingChart
            // 
            chartArea1.Name = "ChartArea1";
            this.pingChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.pingChart.Legends.Add(legend1);
            this.pingChart.Location = new System.Drawing.Point(230, 119);
            this.pingChart.Name = "pingChart";
            this.pingChart.Size = new System.Drawing.Size(558, 368);
            this.pingChart.TabIndex = 11;
            this.pingChart.Text = "Ping Data";
            // 
            // VisualizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 528);
            this.Controls.Add(this.pingChart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportDataButton);
            this.Controls.Add(this.packetLossCheckBox);
            this.Controls.Add(this.latencyCheckBox);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.jobListBox);
            this.Name = "VisualizationForm";
            this.Text = "Data Visualization";
            ((System.ComponentModel.ISupportInitialize)(this.pingChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox jobListBox;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.CheckBox latencyCheckBox;
        private System.Windows.Forms.CheckBox packetLossCheckBox;
        private System.Windows.Forms.Button exportDataButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart pingChart;
    }
}
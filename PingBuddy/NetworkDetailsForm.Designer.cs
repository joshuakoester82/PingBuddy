namespace PingBuddy
{
    partial class NetworkDetailsForm
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
            this.detailsTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // detailsTreeView
            // 
            this.detailsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsTreeView.Location = new System.Drawing.Point(0, 0);
            this.detailsTreeView.Name = "detailsTreeView";
            this.detailsTreeView.Size = new System.Drawing.Size(800, 450);
            this.detailsTreeView.TabIndex = 0;
            // 
            // NetworkDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.detailsTreeView);
            this.Name = "NetworkDetailsForm";
            this.Text = "Network Details";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView detailsTreeView;
    }
}
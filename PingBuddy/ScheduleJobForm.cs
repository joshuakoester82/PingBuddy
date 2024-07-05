using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PingBuddy
{
    public partial class ScheduleJobForm : Form
    {
        private List<PingJob> availableJobs;

        public ScheduleJobForm(List<PingJob> jobs)
        {
            InitializeComponent();
            availableJobs = jobs;
            PopulateAvailableJobs();
        }

        private void PopulateAvailableJobs()
        {
            availableJobsListView.Items.Clear();
            foreach (var job in availableJobs)
            {
                ListViewItem item = new ListViewItem(job.Name);
                item.SubItems.Add(job.Host);
                item.Tag = job;
                availableJobsListView.Items.Add(item);
            }
        }
    }
}
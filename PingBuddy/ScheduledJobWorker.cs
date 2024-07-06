using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Net.NetworkInformation;

namespace PingBuddy
{
    public class ScheduledJobWorker
    {
        private BackgroundWorker worker;
        private List<ScheduledJob> scheduledJobs;
        private readonly object lockObject = new object();

        public event EventHandler<ScheduledJobEventArgs> JobStarted;
        public event EventHandler<ScheduledJobEventArgs> JobCompleted;
        public event EventHandler<PingResultEventArgs> PingCompleted;

        public ScheduledJobWorker(List<ScheduledJob> jobs)
        {
            scheduledJobs = jobs;
            InitializeWorker();
        }

        private void InitializeWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        public void Start()
        {
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        public void Stop()
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                ManageScheduledJobs();
                Thread.Sleep(1000); // Check every second
            }
        }

        private void ManageScheduledJobs()
        {
            lock (lockObject)
            {
                foreach (var job in scheduledJobs.ToList())
                {
                    job.UpdateStatus();

                    if (job.ShouldBeRunning())
                    {
                        if (job.Status == "Pending")
                        {
                            OnJobStarted(job);
                        }

                        PingReply reply = job.ExecutePing();
                        OnPingCompleted(job, reply);

                        // Sleep for the job's interval
                        Thread.Sleep(job.Job.Interval);
                    }
                    else if (job.Status == "Completed" && !job.ResultsExported)
                    {
                        OnJobCompleted(job);
                        job.ResultsExported = true;
                    }
                }
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // Handle or log the error
            }
        }

        protected virtual void OnJobStarted(ScheduledJob job)
        {
            JobStarted?.Invoke(this, new ScheduledJobEventArgs(job));
        }

        protected virtual void OnJobCompleted(ScheduledJob job)
        {
            JobCompleted?.Invoke(this, new ScheduledJobEventArgs(job));
        }

        protected virtual void OnPingCompleted(ScheduledJob job, PingReply reply)
        {
            PingCompleted?.Invoke(this, new PingResultEventArgs(job, reply));
        }

        public void UpdateJobs(List<ScheduledJob> jobs)
        {
            lock (lockObject)
            {
                scheduledJobs = jobs;
            }
        }
    }

    public class ScheduledJobEventArgs : EventArgs
    {
        public ScheduledJob Job { get; }

        public ScheduledJobEventArgs(ScheduledJob job)
        {
            Job = job;
        }
    }

    public class PingResultEventArgs : EventArgs
    {
        public ScheduledJob Job { get; }
        public PingReply Reply { get; }

        public PingResultEventArgs(ScheduledJob job, PingReply reply)
        {
            Job = job;
            Reply = reply;
        }
    }
}
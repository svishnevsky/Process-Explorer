using GrSU.ProcessExplorer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Core.WMI
{
    public delegate void ProcessChangeState(object sender, ProcessChangeStateEventArgs e);

    public class ProcessEventManager : IDisposable
    {
        public event ProcessChangeState ProcessStart;

        public event ProcessChangeState ProcessStop;

        private const string StartProcessQuery = "SELECT * FROM Win32_ProcessStartTrace";

        private const string StopProcessQuery = "SELECT * FROM Win32_ProcessStopTrace";

        private const string ProcessIdPropertyName = "ProcessID";

        private readonly ManagementEventWatcher startProcessWatcher;

        private readonly ManagementEventWatcher stopProcessWatcher;
        
        public ProcessEventManager()
        {
            this.startProcessWatcher = new ManagementEventWatcher(new WqlEventQuery(StartProcessQuery));
            this.startProcessWatcher.EventArrived += startProcessWatcherEventArrived;
            this.startProcessWatcher.Start();
            
            this.stopProcessWatcher = new ManagementEventWatcher(new WqlEventQuery(StopProcessQuery));
            this.stopProcessWatcher.EventArrived += stopProcessWatcherEventArrived;
            this.stopProcessWatcher.Start();
        }

        private void startProcessWatcherEventArrived(object sender, EventArrivedEventArgs e)
        {
            this.OnProcessStart(Convert.ToUInt32(e.NewEvent.Properties[ProcessIdPropertyName].Value));
        }

        private void stopProcessWatcherEventArrived(object sender, EventArrivedEventArgs e)
        {
            this.OnProcessStop(Convert.ToUInt32(e.NewEvent.Properties[ProcessIdPropertyName].Value));
        }

        private void OnProcessStart(uint processId)
        {
            if (ProcessStart == null)
            {
                return;
            }

            ProcessStart(this, new ProcessChangeStateEventArgs
            {
                ProcessId = processId
            });
        }

        private void OnProcessStop(uint processId)
        {
            if (ProcessStop == null)
            {
                return;
            }

            ProcessStop(this, new ProcessChangeStateEventArgs
            {
                ProcessId = processId
            });
        }

        public void Dispose()
        {
            if (this.startProcessWatcher != null)
            {
                this.startProcessWatcher.Stop();
                this.startProcessWatcher.Dispose();
            }


            if (this.stopProcessWatcher != null)
            {
                this.stopProcessWatcher.Stop();
                this.stopProcessWatcher.Dispose();
            }
        }
    }
}

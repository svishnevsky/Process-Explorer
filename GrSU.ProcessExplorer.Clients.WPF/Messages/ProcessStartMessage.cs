using GrSU.ProcessExplorer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Clients.WPF.Messages
{
    public class ProcessStartMessage
    {
        public Process Process { get; private set; }

        public Action<Process, StartedProcessAction> Callback { get; private set; }

        public ProcessStartMessage(Process process, Action<Process, StartedProcessAction> callback)
        {
            this.Process = process;
            this.Callback = callback;
        }
    }
}

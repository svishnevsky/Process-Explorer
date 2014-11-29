using GrSU.ProcessExplorer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Interfaces
{
    public delegate void ProcessStart(object sender, ProcessStartEventArgs e);

    public delegate void ProcessStop(object sender, ProcessStopEventArgs e);

    public interface IProcessManager : IDisposable
    {
        event ProcessStart ProcessStart;

        event ProcessStop ProcessStop;

        IEnumerable<Process> GetProcesses();

        Process GetProcess(uint id);

        void KillProcess(uint id);
    }
}

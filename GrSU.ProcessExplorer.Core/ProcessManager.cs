using GrSU.ProcessExplorer.Core.Native.Kernel32;
using GrSU.ProcessExplorer.Interfaces;
using GrSU.ProcessExplorer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrSU.ProcessExplorer.Core.Mapping;

namespace GrSU.ProcessExplorer.Core
{
    public class ProcessManager : IProcessManager
    {
        internal readonly ProcessHandler ProcessHandler;
        
        public ProcessManager()
        {
            this.ProcessHandler = new ProcessHandler();
        }

        public IEnumerable<Process> GetProcesses()
        {
            return this.ProcessHandler.GetProcesses()
                .Select(item => item.Map<Process>());
        }
    }
}

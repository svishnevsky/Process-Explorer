using GrSU.ProcessExplorer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Interfaces
{
    public interface IProcessManager
    {        
        IEnumerable<Process> GetProcesses();
    }
}

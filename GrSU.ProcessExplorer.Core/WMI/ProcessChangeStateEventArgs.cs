using GrSU.ProcessExplorer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Core.WMI
{
    public class ProcessChangeStateEventArgs : EventArgs
    {
        public uint ProcessId { get; set; }
    }
}

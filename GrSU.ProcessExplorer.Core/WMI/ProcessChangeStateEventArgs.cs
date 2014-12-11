using System;

namespace GrSU.ProcessExplorer.Core.WMI
{
    public class ProcessChangeStateEventArgs : EventArgs
    {
        public uint ProcessId { get; set; }
    }
}

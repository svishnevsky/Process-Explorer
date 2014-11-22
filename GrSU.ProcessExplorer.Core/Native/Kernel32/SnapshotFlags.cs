using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Core.Native.Kernel32
{
    [Flags]
    internal enum SnapshotFlags : int
    {
        HeapList = 0x00000001,
        Process = 0x00000002,
        Thread = 0x00000004,
        Module = 0x00000008,
        Module32 = 0x00000010,
        All = (HeapList | Process | Thread | Module),
        //Inherit = 0x80000000,
        NoHeaps = 0x40000000
    }
}

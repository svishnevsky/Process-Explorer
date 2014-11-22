using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Core.Native.Kernel32
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct PROCESSENTRY32
    {
        const int MAX_PATH = 260;
        internal UInt32 dwSize;
        internal UInt32 cntUsage;
        internal UInt32 th32ProcessID;
        internal IntPtr th32DefaultHeapID;
        internal UInt32 th32ModuleID;
        internal UInt32 cntThreads;
        internal UInt32 th32ParentProcessID;
        internal Int32 pcPriClassBase;
        internal UInt32 dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        internal string szExeFile;
    }
}

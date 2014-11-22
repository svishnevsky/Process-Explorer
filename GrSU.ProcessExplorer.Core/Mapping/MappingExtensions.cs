using GrSU.ProcessExplorer.Core.Native.Kernel32;
using GrSU.ProcessExplorer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Core.Mapping
{
    internal static class MappingExtensions
    {
        public static TResult Map<TResult>(this PROCESSENTRY32 procEntry) where TResult : Process, new()
        {
            return new TResult
            {
                Id = procEntry.th32ProcessID,
                ParentId = procEntry.th32ParentProcessID,
                PriorityClass = procEntry.pcPriClassBase,
                ThreadCount = procEntry.cntThreads,
                Name = procEntry.szExeFile
            };
        }
    }
}

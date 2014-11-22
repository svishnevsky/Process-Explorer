using GrSU.ProcessExplorer.Clients.WPF.Model.ProcessList;
using GrSU.ProcessExplorer.Core.Native.Kernel32;
using GrSU.ProcessExplorer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Clients.WPF.Mapping
{
    internal static class MappingExtensions
    {
        public static TResult Map<TResult>(this Process process) where TResult : ProcessListItem, new()
        {
            return new TResult
            {
                Id = process.Id,
                Name = process.Name
            };
        }
    }
}

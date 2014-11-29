using GrSU.ProcessExplorer.Clients.WPF.Model.ProcessList;
using GrSU.ProcessExplorer.Model;

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

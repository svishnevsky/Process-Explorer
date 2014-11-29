namespace GrSU.ProcessExplorer.Model
{
    public class Process
    {
        public uint Id { get; set; }

        public uint ParentId { get; set; }

        public string Name { get; set; }

        public uint ThreadCount { get; set; }

        public int PriorityClass { get; set; }
    }
}

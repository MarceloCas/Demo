namespace Demo.Core.Infra.CrossCutting.Tests.Models
{
    public class GarbageCollectorResult
    {
        public int TotalGen0 { get; set; }
        public int TotalGen1 { get; set; }
        public int TotalGen2 { get; set; }
        public long TotalKiloBytesOfMemory { get; set; }
    }
}

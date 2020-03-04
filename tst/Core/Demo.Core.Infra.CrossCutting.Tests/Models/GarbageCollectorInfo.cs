using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.Tests.Models
{
    public class GarbageCollectorInfo
    {
        public int Gen0 { get; set; }
        public int Gen1 { get; set; }
        public int Gen2 { get; set; }
        public long TotalBytesOfMemory { get; set; }

        public GarbageCollectorInfo()
        {

        }
        public GarbageCollectorInfo(
            int gen0,
            int gen1,
            int gen2,
            long totalBytesOfMemory)
        {
            Gen0 = gen0;
            Gen1 = gen1;
            Gen2 = gen2;
            TotalBytesOfMemory = totalBytesOfMemory;
        }

        public void Collect()
        {
            Gen0 = GC.CollectionCount(0);
            Gen1 = GC.CollectionCount(1);
            Gen2 = GC.CollectionCount(2);
            TotalBytesOfMemory = GC.GetTotalMemory(true);
        }
    }
}

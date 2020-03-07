using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.Tests.Models
{
    public class GarbageCollectorResult
    {
        public int TotalGen0 { get; set; }
        public int TotalGen1 { get; set; }
        public int TotalGen2 { get; set; }
        public long TotalBytesOfMemory { get; set; }
    }
}

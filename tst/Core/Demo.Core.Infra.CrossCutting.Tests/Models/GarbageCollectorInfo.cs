﻿using System;

namespace Demo.Core.Infra.CrossCutting.Tests.Models
{
    public class GarbageCollectorInfo
    {
        public int Gen0 { get; private set; }
        public int Gen1 { get; private set; }
        public int Gen2 { get; private set; }
        public long TotalBytesOfMemory { get; private set; }

        public void Collect()
        {
            Gen0 = GC.CollectionCount(0);
            Gen1 = GC.CollectionCount(1);
            Gen2 = GC.CollectionCount(2);
            TotalBytesOfMemory = GC.GetTotalMemory(true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.Tests.Models
{
    public class TelemetryCollector
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan TestDuration
        {
            get
            {
                return EndDate - StartDate;
            }
        }

        public GarbageCollectorInfo StartGCInfo { get; private set; }
        public GarbageCollectorInfo EndGCInfo { get; private set; }
        public GarbageCollectorResult GCInfoResult { get; private set; }

        public TelemetryCollector()
        {
            StartGCInfo = new GarbageCollectorInfo();
            EndGCInfo = new GarbageCollectorInfo();
            GCInfoResult = new GarbageCollectorResult();
        }

        public void Start()
        {
            StartGCInfo = new GarbageCollectorInfo();
            EndGCInfo = new GarbageCollectorInfo();
            StartGCInfo.Collect();

            StartDate = DateTime.UtcNow;
        }
        public void Stop()
        {
            EndGCInfo.Collect();

            EndDate = DateTime.UtcNow;

            GCInfoResult = new GarbageCollectorResult
            {
                TotalGen0 = EndGCInfo.Gen0 - StartGCInfo.Gen0,
                TotalGen1 = EndGCInfo.Gen1 - StartGCInfo.Gen1,
                TotalGen2 = EndGCInfo.Gen2 - StartGCInfo.Gen2,
                TotalBytesOfMemory = EndGCInfo.TotalBytesOfMemory - StartGCInfo.TotalBytesOfMemory
            };
        }
    }
}

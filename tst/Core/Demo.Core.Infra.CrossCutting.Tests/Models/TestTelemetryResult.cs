using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.Tests.Models
{
    public class TestTelemetryResult
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

        public GarbageCollectorInfo StartGCInfo { get; set; }
        public GarbageCollectorInfo EndGCInfo { get; set; }
        public GarbageCollectorInfo GCInfoResult { get; set; }

        public void Start()
        {
            var startGCInfo = new GarbageCollectorInfo();
            startGCInfo.Collect();

            StartDate = DateTime.UtcNow;
            StartGCInfo = startGCInfo;
        }
        public void Stop()
        {
            var endGCInfo = new GarbageCollectorInfo();
            endGCInfo.Collect();

            EndDate = DateTime.UtcNow;
            EndGCInfo = endGCInfo;

            GCInfoResult = new GarbageCollectorInfo(
                EndGCInfo.Gen0 - StartGCInfo.Gen0,
                EndGCInfo.Gen1 - StartGCInfo.Gen1,
                EndGCInfo.Gen2 - StartGCInfo.Gen2,
                EndGCInfo.TotalBytesOfMemory - StartGCInfo.TotalBytesOfMemory
                );
        }
    }
}

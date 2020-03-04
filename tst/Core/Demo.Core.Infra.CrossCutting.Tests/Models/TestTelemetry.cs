﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.Tests.Models
{
    public class TestTelemetry
    {
        public bool IsSuccess { get; set; }
        public TestTelemetryResult TestTelemetryResult { get; set; }

        public void StartTelemetry()
        {
            TestTelemetryResult = new TestTelemetryResult();
            TestTelemetryResult.Start();
        }
        public TestTelemetryResult StopTelemetry()
        {
            TestTelemetryResult.Stop();
            return TestTelemetryResult;
        }

        public string GetTelemetryReport(bool writeHeader = true)
        {
            var reportStringBuilder = new StringBuilder();

            if (writeHeader)
            {
                reportStringBuilder.AppendLine(new string('-', 50));
                reportStringBuilder.AppendLine("TELEMETRY RESULT");
                reportStringBuilder.AppendLine(new string('-', 50));
            }

            reportStringBuilder.AppendLine($"Elapsed Time - {TestTelemetryResult.TestDuration}");
            reportStringBuilder.AppendLine($"GEN 0 - {TestTelemetryResult.GCInfoResult.Gen0}");
            reportStringBuilder.AppendLine($"GEN 1 - {TestTelemetryResult.GCInfoResult.Gen1}");
            reportStringBuilder.AppendLine($"GEN 2 - {TestTelemetryResult.GCInfoResult.Gen2}");
            reportStringBuilder.AppendLine($"Total of Memory (Kb) - {TestTelemetryResult.GCInfoResult.TotalBytesOfMemory / 1024.0}");

            return reportStringBuilder.ToString();
        }
    }
}
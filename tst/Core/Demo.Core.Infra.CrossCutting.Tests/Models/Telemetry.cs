using System.Text;

namespace Demo.Core.Infra.CrossCutting.Tests.Models
{
    public class Telemetry
    {
        public bool TestExecutionSuccess { get; set; }
        public TelemetryCollector TelemetryCollector { get; private set; }

        public void StartTelemetry()
        {
            TelemetryCollector = new TelemetryCollector();
            TelemetryCollector.Start();
        }
        public void StopTelemetry()
        {
            TelemetryCollector.Stop();
        }

        public string GetTelemetryReport()
        {
            var reportStringBuilder = new StringBuilder();

            reportStringBuilder.AppendLine(new string('-', 50));
            reportStringBuilder.AppendLine("TELEMETRY RESULT");
            reportStringBuilder.AppendLine(new string('-', 50));

            reportStringBuilder.AppendLine($"Elapsed Time - {TelemetryCollector.TestDuration}");
            reportStringBuilder.AppendLine($"GEN 0 - {TelemetryCollector.GCInfoResult.TotalGen0}");
            reportStringBuilder.AppendLine($"GEN 1 - {TelemetryCollector.GCInfoResult.TotalGen1}");
            reportStringBuilder.AppendLine($"GEN 2 - {TelemetryCollector.GCInfoResult.TotalGen2}");
            reportStringBuilder.AppendLine($"Total of Memory (Kb) - {TelemetryCollector.GCInfoResult.TotalKiloBytesOfMemory / 1024.0}");
            reportStringBuilder.AppendLine($"Total of Memory (Mb) - {TelemetryCollector.GCInfoResult.TotalKiloBytesOfMemory / 1024.0 / 1024.0}");

            return reportStringBuilder.ToString();
        }
    }
}

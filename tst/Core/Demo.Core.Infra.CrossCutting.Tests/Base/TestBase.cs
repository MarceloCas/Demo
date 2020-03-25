﻿using Demo.Core.Infra.CrossCutting.Tests.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.Core.Infra.CrossCutting.Tests.Base
{
    public abstract class TestBase<T>
    {
        private readonly ITestOutputHelper _output;

        protected string Tenant { get; }
        protected CultureInfo CultureInfo { get; }
        protected IServiceProvider ServiceProvider { get; }

        protected TestBase(
            ITestOutputHelper output,
            string tenant = "dev",
            string cultureName = "en-US")
        {
            _output = output;

            /*
             * CultureInfo must be initialized before IoC
             * cause IoC process can be influenced by culture
             */
            CultureInfo = new CultureInfo(cultureName);

            var service = new ServiceCollection();
            ConfigureServices(service);
            ServiceProvider = service.BuildServiceProvider();

            /*
             * 
             */
        }

        private void WriteTelemetryExecutionReport(
            ICollection<Telemetry> telemetryCollection,
            int totalOfExecutions,
            bool hasCustomAcceptanceCriteriaFunction)
        {
            var sb = new StringBuilder();

            var writeHeaderFunction = new Func<int, bool, string>(
                (totalOfExecutions, hasCustomAcceptanceCriteriaFunction) => {
                    var headerTemplate = @"
########################
{0} - Telemetry Execution Report

Executions: {1}
Have Custom Validator: {2}
########################

";

                    return string.Format(
                        headerTemplate,
                        typeof(T).Name,
                        totalOfExecutions,
                        hasCustomAcceptanceCriteriaFunction);
                });

            var writeSummaryFunction = new Func<ICollection<Telemetry>, string>(
                (telemetryCollection) => {
                    var getMedianFunction = new Func<long[], long>(
                        (numbers) => {

                            var length = numbers.Length;
                            var medianLength = length / 2;

                            if (length % 2 == 0)
                            {
                                return (long) Math.Floor((numbers[medianLength - 1] + numbers[medianLength]) / 2.0);
                            }
                            else
                                return (long) Math.Floor(numbers[medianLength] / 1.0);
                        });

                    int minGen0, minGen1, minGen2;
                    int maxGen0, maxGen1, maxGen2;
                    int medianGen0, medianGen1, medianGen2;

                    long minTotalMemory, maxTotalMemory, medianTotalMemory;
                    TimeSpan minElapsedTime, maxElapsedTime, medianElapsedTime;

                    minGen0 = telemetryCollection.Min(q => q.TelemetryCollector.GCInfoResult.TotalGen0);
                    minGen1 = telemetryCollection.Min(q => q.TelemetryCollector.GCInfoResult.TotalGen1);
                    minGen2 = telemetryCollection.Min(q => q.TelemetryCollector.GCInfoResult.TotalGen2);
                    minTotalMemory = telemetryCollection.Min(q => q.TelemetryCollector.GCInfoResult.TotalKiloBytesOfMemory);
                    minElapsedTime = telemetryCollection.Min(q => q.TelemetryCollector.TestDuration);

                    maxGen0 = telemetryCollection.Max(q => q.TelemetryCollector.GCInfoResult.TotalGen0);
                    maxGen1 = telemetryCollection.Max(q => q.TelemetryCollector.GCInfoResult.TotalGen1);
                    maxGen2 = telemetryCollection.Max(q => q.TelemetryCollector.GCInfoResult.TotalGen2);
                    maxTotalMemory = telemetryCollection.Max(q => q.TelemetryCollector.GCInfoResult.TotalKiloBytesOfMemory);
                    maxElapsedTime = telemetryCollection.Max(q => q.TelemetryCollector.TestDuration);

                    medianGen0 = (int) getMedianFunction(telemetryCollection.Select(q => Convert.ToInt64(q.TelemetryCollector.GCInfoResult.TotalGen0)).ToArray());
                    medianGen1 = (int)getMedianFunction(telemetryCollection.Select(q => Convert.ToInt64(q.TelemetryCollector.GCInfoResult.TotalGen1)).ToArray());
                    medianGen2 = (int)getMedianFunction(telemetryCollection.Select(q => Convert.ToInt64(q.TelemetryCollector.GCInfoResult.TotalGen2)).ToArray());
                    medianTotalMemory = getMedianFunction(telemetryCollection.Select(q => q.TelemetryCollector.GCInfoResult.TotalKiloBytesOfMemory).ToArray());
                    medianElapsedTime = TimeSpan.FromTicks(getMedianFunction(telemetryCollection.Select(q => q.TelemetryCollector.TestDuration.Ticks).ToArray()));

                    return
                        $"Summary:\n" +
                        $"\tMIN:\n" +
                        $"\t\tG0: {minGen0}\n" +
                        $"\t\tG1: {minGen1}\n" +
                        $"\t\tG2: {minGen2}\n" +
                        $"\t\tTotalMemory (Kb): {minTotalMemory / 1024.0}\n" +
                        $"\t\tElapsedTime: {minElapsedTime.ToString()}\n" +
                        $"\tMAX:\n" +
                        $"\t\tG0: {maxGen0}\n" +
                        $"\t\tG1: {maxGen1}\n" +
                        $"\t\tG2: {maxGen2}\n" +
                        $"\t\tTotalMemory (Kb): {maxTotalMemory / 1024.0}\n" +
                        $"\t\tElapsedTime: {maxElapsedTime.ToString()}\n" +
                        $"\tMEDIAN:\n" +
                        $"\t\tG0: {medianGen0}\n" +
                        $"\t\tG1: {medianGen1}\n" +
                        $"\t\tG2: {medianGen2}\n" +
                        $"\t\tTotalMemory (Kb): {medianTotalMemory / 1024.0}\n" +
                        $"\t\tElapsedTime: {medianElapsedTime.ToString()}";
                });

            var writeAllTelemetriesFunction = new Func<ICollection<Telemetry>, string>(
                (telemetryCollection) => {
                    var exectutionResultHeaderTemplate = @"

########################
Each execution
########################
";
                    var executionResultTemplate = @"
Execution {0}:
	G0: {1}
	G1: {2}
	G2: {3}
	TotalMemory (Kb): {4}
    Elapsed Time: {5}

";
                    var sb = new StringBuilder();
                    sb.AppendLine(exectutionResultHeaderTemplate);

                    var executionCounter = 0;

                    foreach (var telemetry in telemetryCollection.OrderBy(q => q.TelemetryCollector.StartDate))
                        sb.AppendLine(string.Format(
                            executionResultTemplate,
                            ++executionCounter,
                            telemetry.TelemetryCollector.GCInfoResult.TotalGen0,
                            telemetry.TelemetryCollector.GCInfoResult.TotalGen1,
                            telemetry.TelemetryCollector.GCInfoResult.TotalGen2,
                            telemetry.TelemetryCollector.GCInfoResult.TotalKiloBytesOfMemory / 1024.0,
                            telemetry.TelemetryCollector.TestDuration
                            ));

                    return sb.ToString();
                });

            sb.Append(writeHeaderFunction(totalOfExecutions, hasCustomAcceptanceCriteriaFunction));
            sb.Append(writeSummaryFunction(telemetryCollection));
            sb.Append(writeAllTelemetriesFunction(telemetryCollection));

            _output.WriteLine(sb.ToString());
        }

        protected void WriteLog(string message)
        {
            _output.WriteLine($"{DateTime.UtcNow} - {message}");
        }
        protected abstract void ConfigureServices(IServiceCollection services);

        protected async Task<List<Telemetry>> RunWithTelemetry(
            Func<Task<bool>> testFunction,
            int totalOfExecutions = 1,
            Func<List<Telemetry>, bool> customAcceptanceCriteriaFunction = null)
        {
            var telemetryCollection = new List<Telemetry>();

            var hasCustomAcceptanceCriteriaFunction = customAcceptanceCriteriaFunction != null;

            for (int i = 0; i < totalOfExecutions; i++)
            {
                var telemetry = new Telemetry();

                telemetry.StartTelemetry();
                telemetry.TestExecutionSuccess = await testFunction.Invoke();
                telemetry.StopTelemetry();

                telemetryCollection.Add(telemetry);
            }

            if (!hasCustomAcceptanceCriteriaFunction)
                Assert.True(telemetryCollection.All(q => q.TestExecutionSuccess));
            else
                Assert.True(customAcceptanceCriteriaFunction(telemetryCollection));

            WriteTelemetryExecutionReport(
                telemetryCollection, 
                totalOfExecutions, 
                hasCustomAcceptanceCriteriaFunction);

            return telemetryCollection;
        }
    }
}

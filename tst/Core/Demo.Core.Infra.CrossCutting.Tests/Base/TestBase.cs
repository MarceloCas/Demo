using Demo.Core.Infra.CrossCutting.Tests.Models;
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
        protected CultureInfo CultureInfo { get; set; }
        protected IServiceProvider ServiceProvider { get; }
        public ITestOutputHelper Output { get; }

        protected TestBase(ITestOutputHelper output, string cultureName = "en-US")
        {
            CultureInfo = new CultureInfo(cultureName);
            Output = output;
            var service = new ServiceCollection();

            ConfigureServices(service);
            ServiceProvider = service.BuildServiceProvider();
            ServiceProviderGenerated(ServiceProvider);
        }

        private TestTelemetry CreateAndStartTelemetry()
        {
            var testTelemetry = new TestTelemetry();
            testTelemetry.StartTelemetry();

            return testTelemetry;
        }
        private void StopTelemetry(TestTelemetry testTelemetry)
        {
            testTelemetry.StopTelemetry();
        }
        private void WriteHeadTelemetry(TestTelemetry testTelemetry)
        {
            Output.WriteLine(new string('*', 100));
            Output.WriteLine("AVERAGE RESULT");
            Output.WriteLine(new string('*', 100));
            Output.WriteLine(testTelemetry.GetTelemetryReport(false));
        }
        private void WriteTelemetry(TestTelemetry testTelemetry)
        {
            Output.WriteLine(testTelemetry.GetTelemetryReport());
        }

        protected abstract void ConfigureServices(IServiceCollection services);
        protected abstract void ServiceProviderGenerated(IServiceProvider serviceProvider);

        protected async Task<List<TestTelemetry>> RunWithTelemetry(
            Func<Task<bool>> executionFunction, 
            int totalOfExecutions = 1,
            Func<List<TestTelemetry>, bool> acceptCriteriaFunction = null)
        {
            var telemetryResultCollection = new List<TestTelemetry>();

            for (int i = 0; i < totalOfExecutions; i++)
            {
                var telemetry = CreateAndStartTelemetry();
                var testExecutionResult = await executionFunction.Invoke();
                telemetry.IsSuccess = testExecutionResult;
                StopTelemetry(telemetry);

                telemetryResultCollection.Add(telemetry);
            }

            WriteHeadTelemetry(new TestTelemetry { 
                TestTelemetryResult = new TestTelemetryResult
                {
                    StartDate = telemetryResultCollection.Select(q => q.TestTelemetryResult.StartDate).Min(),
                    EndDate = telemetryResultCollection.Select(q => q.TestTelemetryResult.EndDate).Max(),
                    GCInfoResult = new GarbageCollectorInfo
                    {
                        Gen0 = (int) telemetryResultCollection.Select(q => q.TestTelemetryResult.GCInfoResult.Gen0).Average(),
                        Gen1 = (int) telemetryResultCollection.Select(q => q.TestTelemetryResult.GCInfoResult.Gen1).Average(),
                        Gen2 = (int) telemetryResultCollection.Select(q => q.TestTelemetryResult.GCInfoResult.Gen2).Average(),
                        TotalBytesOfMemory = (long) telemetryResultCollection.Select(q => q.TestTelemetryResult.GCInfoResult.TotalBytesOfMemory).Average()
                    }
                }
            });

            Output.WriteLine(new string('*', 100));
            Output.WriteLine("SINGLE RESULT OF EACH EXECUTION");
            Output.WriteLine(new string('*', 100));

            foreach (var telemetryResult in telemetryResultCollection)
                WriteTelemetry(telemetryResult);

            if (acceptCriteriaFunction != null)
                Assert.True(acceptCriteriaFunction(telemetryResultCollection));
            else
                Assert.True(!telemetryResultCollection.Any(q => !q.IsSuccess));

            return await Task.FromResult(telemetryResultCollection);
        }


    }
}

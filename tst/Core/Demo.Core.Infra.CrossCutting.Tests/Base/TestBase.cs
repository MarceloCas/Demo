using Demo.Core.Infra.CrossCutting.Tests.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private void StopAndWriteTelemetry(TestTelemetry testTelemetry)
        {
            testTelemetry.StopTelemetry();
            Output.WriteLine(testTelemetry.GetTelemetryReport());
        }

        protected abstract void ConfigureServices(IServiceCollection services);
        protected abstract void ServiceProviderGenerated(IServiceProvider serviceProvider);

        protected async Task<bool> RunWithTelemetry(Func<Task<bool>> executionFunction)
        {
            var telemetry = CreateAndStartTelemetry();
            var testResult = await executionFunction.Invoke();
            StopAndWriteTelemetry(telemetry);

            Assert.True(testResult);
            return await Task.FromResult(true);
        }


    }
}

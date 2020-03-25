using Demo.Core.Infra.CrossCutting.Tests.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.Core.Infra.CrossCutting.Tests.DesignPatterns.Factories
{
    public class FactoryTest
        : TestBase<FactoryTest>
    {
        public FactoryTest(ITestOutputHelper output, string cultureName = "en-US") 
            : base(output, cultureName)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
        }

        [Fact]
        public async Task TestMethod()
        {
            await RunWithTelemetry(
                async () => {
                    var teste = "a" + DateTime.UtcNow.ToString();
                    return await Task.FromResult(true);
                },
                1000);
        }
        [Fact]
        public async Task TestMethod2()
        {
            await RunWithTelemetry(
                async () => {
                    var teste = "a" + DateTime.UtcNow.ToString();
                    return await Task.FromResult(true);
                },
                1000,
                (telemetryCollection) => {
                    return telemetryCollection.All(q => q.TestExecutionSuccess)
                    && telemetryCollection.Select(q => q.TelemetryCollector.GCInfoResult.TotalKiloBytesOfMemory).Average() <= 200;
                }
            );
        }
    }
}

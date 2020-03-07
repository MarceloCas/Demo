using Demo.Core.Infra.CrossCutting.Tests.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                    return await Task.FromResult(true);
                },
                100);
        }
        [Fact]
        public async Task TestMethod2()
        {
            await RunWithTelemetry(
                // Função do teste
                async () => {
                    return await Task.FromResult(true);
                },
                // Total de execuções
                10,
                // Critério de aceitação customizado
                (q) => {
                    return q.Select(q => q.TelemetryCollector.GCInfoResult.TotalBytesOfMemory).Average() <= 3_000;
                }
            );
        }
    }
}

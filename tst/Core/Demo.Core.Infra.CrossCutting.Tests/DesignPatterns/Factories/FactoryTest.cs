using Demo.Core.Infra.CrossCutting.Tests.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
        protected override void ServiceProviderGenerated(IServiceProvider serviceProvider)
        {
        }

        [Fact]
        public async Task TestMethod()
        {
            await RunWithTelemetry(async () => {
                return await Task.FromResult(true);
            }, 10);
        }

    }
}

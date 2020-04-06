using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.IoC;
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
        public FactoryTest(
            ITestOutputHelper output,
            string tenantCode = "dev",
            string creationUser = "unitTest",
            LocalizationsEnum localization = LocalizationsEnum.Default,
            string cultureName = "en-US"
            ) : base(output, tenantCode, creationUser, localization, cultureName)
        {
        }

        protected override BootstrapperBase GetBootstrapper(IServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}

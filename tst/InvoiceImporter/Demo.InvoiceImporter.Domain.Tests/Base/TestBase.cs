using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Demo.InvoiceImporter.Domain.Tests.Base
{
    public abstract class TestBase<T>
        : Core.Infra.CrossCutting.Tests.Base.TestBase<T>
    {
        protected TestBase(
            ITestOutputHelper output, 
            string tenantCode = "dev", 
            string creationUser = "unitTest", 
            LocalizationsEnum localization = LocalizationsEnum.Default,
            string cultureName = "en-US") 
            : base(output, tenantCode, creationUser, localization, cultureName)
        {

        }

        protected override BootstrapperBase GetBootstrapper(IServiceCollection services)
        {
            return new Infra.IoC.Tests.DefaultBootstrapper(services, TenantCode, CultureName, Localization);
        }
    }
}

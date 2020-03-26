using Demo.Core.Infra.CrossCutting.Globalization.Enums;
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
            string tenant = "dev", 
            string creationUser = "unitTest", 
            LocalizationsEnum localization = LocalizationsEnum.Default,
            string cultureName = "en-US") 
            : base(output, tenant, creationUser, localization, cultureName)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            new Infra.IoC.Tests.DefaultBootstrapper().RegisterServices(services, Tenant, CultureName, Localization);
        }
    }
}

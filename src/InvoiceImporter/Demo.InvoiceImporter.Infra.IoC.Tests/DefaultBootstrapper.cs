using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo.InvoiceImporter.Infra.IoC.Tests
{
    public class DefaultBootstrapper
    {
        public void RegisterServices(IServiceCollection services, string tenantCode, string cultureName, LocalizationsEnum localization)
        {
            new Core.Infra.CrossCutting.IoC.DefaultBootstrapper().RegisterServices(services, cultureName, localization);
            new Core.Domain.IoC.DefaultBootstrapper().RegisterServices(services, tenantCode);
            new Domain.IoC.DefaultBootstrapper().RegisterServices(services);
            new Infra.Data.IoC.DefaultBootstrapper().RegisterServices(services);
        }
    }
}

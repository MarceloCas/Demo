using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using static Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumberValueObject;
using static Demo.Core.Domain.ValueObjects.TenantInfoValueObject;

namespace Demo.Core.Domain.IoC
{
    public class DefaultBootstrapper
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITenantInfoValueObjectFactory, TenantInfoValueObjectFactory>();
            services.AddScoped<IGovernamentalDocumentNumberValueObjectFactory, GovernamentalDocumentNumberValueObjectFactory>();
        }
    }
}

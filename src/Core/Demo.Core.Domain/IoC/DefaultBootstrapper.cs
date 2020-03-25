using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.Factories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using static Demo.Core.Domain.ValueObjects.CNPJs.CNPJValueObject;
using static Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.GovernamentalDocumentNumberValueObject;
using static Demo.Core.Domain.ValueObjects.TenantInfoValueObject;

namespace Demo.Core.Domain.IoC
{
    public class DefaultBootstrapper
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITenantInfoValueObjectFactory, TenantInfoValueObjectFactory>();
            services.AddScoped<IGovernamentalDocumentNumberValueObjectFactory, GovernamentalDocumentNumberValueObjectFactory>();
            services.AddScoped<ICNPJValueObjectFactory, CNPJValueObjectFactory>();
        }
    }
}

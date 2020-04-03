using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels;
using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
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
        public void RegisterServices(IServiceCollection services, string tenantCode)
        {
            RegisterValueObjects(services, tenantCode);
            RegisterFactories(services, tenantCode);
            RegisterDomainModelSpecifications(services, tenantCode);
        }

        private void RegisterValueObjects(IServiceCollection services, string tenantCode)
        {
            services.AddScoped<ITenantInfoValueObjectFactory>(serviceProvider => {
                var globalizationConfig = serviceProvider.GetService<IGlobalizationConfig>();

                return new TenantInfoValueObjectFactory(globalizationConfig, tenantCode);
            });
        }
        private void RegisterFactories(IServiceCollection services, string tenantCode)
        {
            services.AddScoped<IGovernamentalDocumentNumberValueObjectFactory, GovernamentalDocumentNumberValueObjectFactory>();
            services.AddScoped<ICNPJValueObjectFactory, CNPJValueObjectFactory>();
        }

        private void RegisterDomainModelSpecifications(IServiceCollection services, string tenantCode)
        {
            services.AddScoped<IDomainModelMustHaveIdSpecification, DomainModelMustHaveIdSpecification>();
            services.AddScoped<IDomainModelMustExistsSpecification, DomainModelMustExistsSpecification>();
        }
    }
}

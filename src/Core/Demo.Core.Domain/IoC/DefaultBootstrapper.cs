using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels;
using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.IoC;
using Demo.Core.Infra.CrossCutting.IoC.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using static Demo.Core.Domain.ValueObjects.CNPJs.CNPJValueObject;
using static Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.GovernamentalDocumentNumberValueObject;
using static Demo.Core.Domain.ValueObjects.TenantInfoValueObject;

namespace Demo.Core.Domain.IoC
{
    public class DefaultBootstrapper
        : BootstrapperBase
    {
        // Constructors
        public DefaultBootstrapper(
            IServiceCollection services,
            string tenantCode,
            string cultureName,
            LocalizationsEnum localization)
            : base(services, tenantCode, cultureName, localization)
        {
        }

        // Private Methods
        private TypeRegistration[] RegisterValueObjects()
        {
            return new[] {
                new TypeRegistration(typeof(ITenantInfoValueObjectFactory), new Func<IServiceProvider, object>(serviceProvider =>
                    {
                        var globalizationConfig = serviceProvider.GetService<IGlobalizationConfig>();

                        return new TenantInfoValueObjectFactory(globalizationConfig, TenantCode);
                    })
                )
            };
        }
        private TypeRegistration[] RegisterFactories()
        {
            return new[] {
                new TypeRegistration(typeof(IGovernamentalDocumentNumberValueObjectFactory), typeof(GovernamentalDocumentNumberValueObjectFactory)),
                new TypeRegistration(typeof(ICNPJValueObjectFactory), typeof(CNPJValueObjectFactory))
            };
        }
        private TypeRegistration[] RegisterDomainModelSpecifications()
        {
            return new[] {
                new TypeRegistration (typeof(IDomainModelMustExistsSpecification), typeof(DomainModelMustExistsSpecification)),
                new TypeRegistration (typeof(IDomainModelMustHaveCreationDateSpecification), typeof(DomainModelMustHaveCreationDateSpecification)),
                new TypeRegistration (typeof(IDomainModelMustHaveCreationUserSpecification), typeof(DomainModelMustHaveCreationUserSpecification)),
                new TypeRegistration (typeof(IDomainModelMustHaveIdSpecification), typeof(DomainModelMustHaveIdSpecification)),
                new TypeRegistration (typeof(IDomainModelMustHaveModificationDateGreaterThanCreationDateSpecification), typeof(DomainModelMustHaveModificationDateGreaterThanCreationDateSpecification)),
                new TypeRegistration (typeof(IDomainModelMustHaveModificationDateSpecification), typeof(DomainModelMustHaveModificationDateSpecification)),
                new TypeRegistration (typeof(IDomainModelMustHaveModificationUserSpecification), typeof(DomainModelMustHaveModificationUserSpecification)),
                new TypeRegistration (typeof(IDomainModelMustHaveTenantCodeSpecification), typeof(DomainModelMustHaveTenantCodeSpecification)),
                new TypeRegistration (typeof(IDomainModelMustHaveTenantCodeWithValidLengthSpecification), typeof(DomainModelMustHaveTenantCodeWithValidLengthSpecification)),
                new TypeRegistration (typeof(IDomainModelMustNotExistsSpecification), typeof(DomainModelMustNotExistsSpecification))
            };
        }

        // Public Methods
        public override TypeRegistration[] GetTypeRegistrationCollection()
        {
            var typeRegistrationList = new List<TypeRegistration>();

            typeRegistrationList.AddRange(RegisterValueObjects());
            typeRegistrationList.AddRange(RegisterFactories());
            typeRegistrationList.AddRange(RegisterDomainModelSpecifications());

            return typeRegistrationList.ToArray();
        }
    }
}

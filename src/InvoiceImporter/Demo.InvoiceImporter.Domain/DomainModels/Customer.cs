using Demo.Core.Domain.ValueObjects.CNPJs;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Base;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainModels
{
    public class Customer
        : CustomerBase
    {
        protected Customer(GovernamentalDocumentNumberValueObject governamentalDocumentNumberValueObject) 
            : base(governamentalDocumentNumberValueObject)
        {
        }

        // Public Methods
        public override Customer ImportCustomer<Customer>(string tenantCode, string name, string governamentalNumber, string creationUser)
        {
            return base.ImportCustomer<Customer>(tenantCode, name, governamentalNumber, creationUser);
        }

        #region Localizations
        public class BrazilianCustomer
            : Customer
        {
            protected BrazilianCustomer(CNPJValueObject cnpjValueObject)
                : base(cnpjValueObject)
            {

            }

            // Public Methods
            public override BrazilianCustomer ImportCustomer<BrazilianCustomer>(string tenantCode, string name, string governamentalNumber, string creationUser)
            {
                return base.ImportCustomer<BrazilianCustomer>(tenantCode, name, governamentalNumber, creationUser);
            }

            #region Factories
            public class BrazilianCustomerFactory
                : DomainModelBaseFactory<BrazilianCustomer>,
                IBrazilianCustomerFactory
            {
                private readonly ICNPJValueObjectFactory _cnpjValueObjectFactory;

                public BrazilianCustomerFactory(
                    ICNPJValueObjectFactory cnpjValueObjectFactory,
                    ITenantInfoValueObjectFactory tenantInfoValueObjectFactory, 
                    IGlobalizationConfig globalizationConfig) 
                    : base(tenantInfoValueObjectFactory, globalizationConfig)
                {
                    _cnpjValueObjectFactory = cnpjValueObjectFactory;
                }

                public override BrazilianCustomer Create()
                {
                    return new BrazilianCustomer(_cnpjValueObjectFactory.Create());
                }
            }
            #endregion
        }
        #endregion

        #region Factories
        public class CustomerFactory
            : DomainModelBaseFactory<Customer>,
            ICustomerFactory
        {
            private readonly IBrazilianCustomerFactory _brazilianCustomerFactory;
            private readonly IGovernamentalDocumentNumberValueObjectFactory _governamentalDocumentNumberValueObjectFactory;

            public CustomerFactory(
                IBrazilianCustomerFactory brazilianCustomerFactory,
                IGovernamentalDocumentNumberValueObjectFactory governamentalDocumentNumberValueObjectFactory,
                ITenantInfoValueObjectFactory tenantInfoValueObjectFactory,
                IGlobalizationConfig globalizationConfig)
                : base(tenantInfoValueObjectFactory, globalizationConfig)
            {
                _governamentalDocumentNumberValueObjectFactory = governamentalDocumentNumberValueObjectFactory;
                _brazilianCustomerFactory = brazilianCustomerFactory;
            }

            public override Customer Create()
            {

                switch (GlobalizationConfig.Localization)
                {
                    case Core.Infra.CrossCutting.DesignPatterns.Globalization.Enums.LocalizationsEnum.Default:
                        return RegisterBaseTypes(new Customer(_governamentalDocumentNumberValueObjectFactory.Create()));
                    case Core.Infra.CrossCutting.DesignPatterns.Globalization.Enums.LocalizationsEnum.Brazil:
                        return RegisterBaseTypes(_brazilianCustomerFactory.Create());
                    default:
                        return RegisterBaseTypes(new Customer(_governamentalDocumentNumberValueObjectFactory.Create()));
                }
            }
        }
        #endregion
    }
}

using Demo.Core.Domain.ValueObjects.CNPJs;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice;
using Demo.InvoiceImporter.Domain.DomainModels.Base;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using System.Threading.Tasks;

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

                public override async Task<BrazilianCustomer> CreateAsync()
                {
                    return await Task.FromResult(
                        new BrazilianCustomer(await _cnpjValueObjectFactory.CreateAsync())
                        );
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

            public override async Task<Customer> CreateAsync()
            {
                return GlobalizationConfig.Localization switch
                {
                    Core.Infra.CrossCutting.Globalization.Enums.LocalizationsEnum.Default => await RegisterBaseTypesAsync(new Customer(await _governamentalDocumentNumberValueObjectFactory.CreateAsync())),
                    Core.Infra.CrossCutting.Globalization.Enums.LocalizationsEnum.Brazil => await RegisterBaseTypesAsync(await _brazilianCustomerFactory.CreateAsync()),
                    _ => await RegisterBaseTypesAsync(new Customer(await _governamentalDocumentNumberValueObjectFactory.CreateAsync())),
                };
            }

            public async Task<Customer> CreateAsync(ImportInvoiceCommand parameter)
            {
                var customer = await CreateAsync();

                customer.SetName(parameter?.Customer?.Name);
                customer.SetGovernamentalDocumentNumber(parameter?.Customer?.GovernamentalDocumentNumber);

                return customer;
            }
        }
        #endregion
    }
}

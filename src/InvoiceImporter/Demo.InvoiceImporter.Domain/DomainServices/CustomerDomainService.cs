using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Events.Customers.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class CustomerDomainService
        : DomainServiceBase<Customer>,
        ICustomerDomainService
    {
        private readonly ICustomerIsValidForImportValidation _customerIsValidForImportValidation;

        private readonly IGetCustomerByGovernamentalDocumentNumberQueryFactory _getCustomerByGovernamentalDocumentNumberQueryFactory;
        private readonly IGetCustomerByGovernamentalDocumentNumberQueryAdapter _getCustomerByGovernamentalDocumentNumberQueryAdapter;

        private readonly ICustomerWasImportedEventFactory _customerWasImportedEventFactory;
        private readonly ICustomerWasUpdatedEventFactory _customerWasUpdatedEventFactory;

        public CustomerDomainService(
            IBus bus,
            ICustomerFactory factory,
            ICustomerIsValidForImportValidation customerIsValidForImportValidation,
            IGetCustomerByGovernamentalDocumentNumberQueryFactory getCustomerByGovernamentalDocumentNumberQueryFactory,
            IGetCustomerByGovernamentalDocumentNumberQueryAdapter getCustomerByGovernamentalDocumentNumberQueryAdapter,
            ICustomerWasImportedEventFactory customerWasImportedEventFactory,
            ICustomerWasUpdatedEventFactory customerWasUpdatedEventFactory
            ) : base(bus, factory)
        {
            _customerIsValidForImportValidation = customerIsValidForImportValidation;
            _customerWasImportedEventFactory = customerWasImportedEventFactory;
            _getCustomerByGovernamentalDocumentNumberQueryAdapter = getCustomerByGovernamentalDocumentNumberQueryAdapter;
            _getCustomerByGovernamentalDocumentNumberQueryFactory = getCustomerByGovernamentalDocumentNumberQueryFactory;
            _customerWasUpdatedEventFactory = customerWasUpdatedEventFactory;
        }

        public async Task<Customer> ImportCustomerAsync(string tenantCode, string creationUser, Customer customerToImport)
        {
            /* Validate */
            if (await ValidateAsync(customerToImport, _customerIsValidForImportValidation) == false)
                return customerToImport;

            /* Process */

            // 1º Step - Import customer
            var importedCustomer = (await Factory.CreateAsync()).ImportCustomer<Customer>(
                tenantCode,
                customerToImport.Name,
                customerToImport.GovernamentalDocumentNumber,
                creationUser);

            // 2º Step - Check and get a existing customer by governamental document number
            var getCustomerByGovernamentalDocumentNumberQuery = await _getCustomerByGovernamentalDocumentNumberQueryAdapter.AdapteeAsync(
                importedCustomer,
                await _getCustomerByGovernamentalDocumentNumberQueryFactory.CreateAsync());
            var existingCustomer = await Bus.SendQueryAsync(getCustomerByGovernamentalDocumentNumberQuery);

            // 3º Step - Change Id if customer existing
            var hasExistingCustomer = (existingCustomer?.Id ?? Guid.Empty) != Guid.Empty;
            if (hasExistingCustomer)
                importedCustomer.ChangeId(existingCustomer.Id);

            /* Notify */
            if (!hasExistingCustomer)
                _ = await Bus.SendEventAsync(await _customerWasImportedEventFactory.CreateAsync(importedCustomer));
            else
                _ = await Bus.SendEventAsync(await _customerWasUpdatedEventFactory.CreateAsync(importedCustomer));

            return importedCustomer;
        }
    }
}

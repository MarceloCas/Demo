using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Events.Customers.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class CustomerDomainService
        : DomainServiceBase<Customer>,
        ICustomerDomainService
    {
        private readonly ICustomerIsValidForImportValidation _customerIsValidForImportValidation;
        private readonly ICustomerWasImportedEventFactory _customerWasImportedEventFactory;

        public CustomerDomainService(
            IBus bus,
            ICustomerFactory factory,
            ICustomerIsValidForImportValidation customerIsValidForImportValidation,
            ICustomerWasImportedEventFactory customerWasImportedEventFactory
            ) : base(bus, factory)
        {
            _customerIsValidForImportValidation = customerIsValidForImportValidation;
            _customerWasImportedEventFactory = customerWasImportedEventFactory;
        }

        public async Task<Customer> ImportCustomerAsync(string tenantCode, string creationUser, Customer customerToImport)
        {
            // Validate
            if (await ValidateAsync(customerToImport, _customerIsValidForImportValidation) == false)
                return customerToImport;

            // Process
            var importedCustomer = (await Factory.CreateAsync()).ImportCustomer<Customer>(
                tenantCode,
                customerToImport.Name,
                customerToImport.GovernamentalDocumentNumber,
                creationUser);

            // Notify
            _ = await Bus.SendEventAsync(await _customerWasImportedEventFactory.CreateAsync(importedCustomer));

            return importedCustomer;
        }
    }
}

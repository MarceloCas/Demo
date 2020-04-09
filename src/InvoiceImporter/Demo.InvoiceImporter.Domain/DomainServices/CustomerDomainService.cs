using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class CustomerDomainService
        : DomainServiceBase<Customer>,
        ICustomerDomainService
    {
        private readonly ICustomerIsValidForImportValidation _customerIsValidForImportValidation;

        public CustomerDomainService(
            IBus bus,
            ICustomerFactory factory,
            ICustomerIsValidForImportValidation customerIsValidForImportValidation
            ) : base(bus, factory)
        {
            _customerIsValidForImportValidation = customerIsValidForImportValidation;
        }

        public async Task<Customer> ImportCustomerAsync(string tenantCode, string creationUser, Customer customerToImport)
        {
            if (await ValidateAsync(customerToImport, _customerIsValidForImportValidation) == false)
                return customerToImport;

            var importedCustomer = (await Factory.CreateAsync()).ImportCustomer<Customer>(
                tenantCode,
                customerToImport.Name,
                customerToImport.GovernamentalDocumentNumber,
                creationUser);

            //importedCustomer = await Repository.AddAsync(importedCustomer);

            return importedCustomer;
        }
    }
}

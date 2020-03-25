using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class CustomerDomainService
        : DomainServiceBase<Customer>,
        ICustomerDomainService
    {
        private readonly ICustomerIsValidForImportValidation _customerIsValidForImportValidation;

        public CustomerDomainService(
            ICustomerRepository repository,
            ICustomerFactory factory,
            ICustomerIsValidForImportValidation customerIsValidForImportValidation
            ) 
            : base(repository, factory)
        {
            _customerIsValidForImportValidation = customerIsValidForImportValidation;
        }

        public async Task<Customer> ImportCustomerAsync(string tenantCode, string creationUser, Customer customerToImport)
        {
            var validationResult = await _customerIsValidForImportValidation.Validate(customerToImport);
            if (!validationResult.IsValid)
            {
                // Send DomainNotification

                return customerToImport;
            }

            var importedCustomer = Factory.Create().ImportCustomer(
                tenantCode,
                customerToImport.Name,
                customerToImport.GovernamentalDocumentNumber,
                creationUser);

            importedCustomer = await Repository.AddAsync(importedCustomer);

            return importedCustomer;
        }
    }
}

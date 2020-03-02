using Demo.Core.Domain.Repositories.Base;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class CustomerDomainService
        : DomainServiceBase<Customer>,
        ICustomerDomainService
    {
        public CustomerDomainService(
            ICustomerRepository repository,
            ICustomerFactory factory) 
            : base(repository, factory)
        {

        }

        public async Task<Customer> ImportCustomerAsync(string tenantCode, string creationUser, Customer customerToImport)
        {
            // Validation

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

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
    public class InvoiceDomainService
        : DomainServiceBase<Invoice>,
        IInvoiceDomainService
    {
        public InvoiceDomainService(
            IInvoiceRepository repository,
            IInvoiceFactory invoiceFactory) 
            : base(repository, invoiceFactory)
        {
        }

        public async Task<Invoice> ImportInvoiceAsync(string tenantCode, string creationUser, Invoice invoiceToImport)
        {
            // Validation

            var importedInvoice = Factory.Create().ImportInvoice(
                tenantCode,
                invoiceToImport.Code,
                invoiceToImport.Date,
                invoiceToImport.Customer,
                invoiceToImport.InvoiceItemCollection,
                creationUser);

            importedInvoice = await Bus.AddAsync(importedInvoice);

            return importedInvoice;
        }
    }
}

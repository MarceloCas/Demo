using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class InvoiceDomainService
        : DomainServiceBase<Invoice>,
        IInvoiceDomainService
    {
        public InvoiceDomainService(
            IBus bus,
            IInvoiceFactory invoiceFactory) 
            : base(bus, invoiceFactory)
        {
        }

        public async Task<Invoice> ImportInvoiceAsync(string tenantCode, string creationUser, Invoice invoiceToImport)
        {
            // Validation

            var importedInvoice = (await Factory.CreateAsync()).ImportInvoice(
                tenantCode,
                invoiceToImport.Code,
                invoiceToImport.Date,
                invoiceToImport.Customer,
                invoiceToImport.InvoiceItemCollection,
                creationUser);

            return importedInvoice;
        }
    }
}

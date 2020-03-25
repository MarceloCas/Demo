using Demo.Core.Domain.DomainServices.Base.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices.Interfaces
{
    public interface IInvoiceDomainService
        : IDomainService<Invoice>
    {
        Task<Invoice> ImportInvoiceAsync(string tenantCode, string creationUser, Invoice invoiceToImport);
    }
}

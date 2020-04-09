using Demo.Core.Domain.DomainServices.Base.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices.Interfaces
{
    public interface IProductDomainService
        : IDomainService<Product>
    {
        Task<Product> ImportProductAsync(string tenantCode, string creationUser, Product productToImport);
    }
}

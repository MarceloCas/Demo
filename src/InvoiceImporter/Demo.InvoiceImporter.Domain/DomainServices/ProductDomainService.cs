using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class ProductDomainService
        : DomainServiceBase<Product>,
        IProductDomainService
    {
        public ProductDomainService(
            IBus bus,
            IProductFactory productFactory) 
            : base(bus, productFactory)
        {
        }

        public async Task<Product> ImportProductAsync(string tenantCode, string creationUser, Product productToImport)
        {
            // Validation

            var importedProduct = (await Factory.CreateAsync()).ImportProduct(
                tenantCode,
                productToImport.Name,
                productToImport.Code,
                creationUser);

            return importedProduct;
        }
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Events.Products.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class ProductDomainService
        : DomainServiceBase<Product>,
        IProductDomainService
    {
        private readonly IProductWasImportedEventFactory _productWasImportedEventFactory;

        public ProductDomainService(
            IBus bus,
            IProductFactory productFactory,
            IProductWasImportedEventFactory productWasImportedEventFactory
            ) 
            : base(bus, productFactory)
        {
            _productWasImportedEventFactory = productWasImportedEventFactory;
        }

        public async Task<Product> ImportProductAsync(string tenantCode, string creationUser, Product productToImport)
        {
            // Validation

            // Process
            var importedProduct = (await Factory.CreateAsync()).ImportProduct(
                tenantCode,
                productToImport.Name,
                productToImport.Code,
                creationUser);

            // Notify
            _ = await Bus.SendEventAsync(await _productWasImportedEventFactory.CreateAsync(importedProduct));

            return importedProduct;
        }
    }
}

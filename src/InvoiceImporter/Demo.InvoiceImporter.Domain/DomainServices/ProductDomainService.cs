using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Products.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Events.Products.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Products.Adapters.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Products.Factories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class ProductDomainService
        : DomainServiceBase<Product>,
        IProductDomainService
    {
        private readonly IProductIsValidForImportValidation _productIsValidForImportValidation;

        private readonly IGetProductByCodeQueryFactory _getProductByCodeQueryFactory;
        private readonly IGetProductByCodeQueryAdapter _getProductByCodeQueryAdapter;

        private readonly IProductWasImportedEventFactory _productWasImportedEventFactory;
        private readonly IProductWasUpdatedEventFactory _productWasUpdatedEventFactory;

        public ProductDomainService(
            IBus bus,
            IProductFactory productFactory,
            IProductIsValidForImportValidation productIsValidForImportValidation,
            IGetProductByCodeQueryFactory getProductByCodeQueryFactory,
            IGetProductByCodeQueryAdapter getProductByCodeQueryAdapter,
            IProductWasImportedEventFactory productWasImportedEventFactory,
            IProductWasUpdatedEventFactory productWasUpdatedEventFactory
            ) 
            : base(bus, productFactory)
        {
            _productIsValidForImportValidation = productIsValidForImportValidation;
            _getProductByCodeQueryFactory = getProductByCodeQueryFactory;
            _getProductByCodeQueryAdapter = getProductByCodeQueryAdapter;
            _productWasImportedEventFactory = productWasImportedEventFactory;
            _productWasUpdatedEventFactory = productWasUpdatedEventFactory;
        }

        public async Task<Product> ImportProductAsync(string tenantCode, string creationUser, Product productToImport)
        {
            /* Validate */
            if (await ValidateAsync(productToImport, _productIsValidForImportValidation) == false)
                return productToImport;

            /* Process */

            // 1º Step - Import product
            var importedProduct = (await Factory.CreateAsync()).ImportProduct(
                tenantCode,
                productToImport.Name,
                productToImport.Code,
                creationUser);

            // 2º Step - Check and get a existing product by governamental document number
            var getProductByCodeQuery = await _getProductByCodeQueryAdapter.AdapteeAsync(
                importedProduct,
                await _getProductByCodeQueryFactory.CreateAsync());
            var existingProduct = (await Bus.SendQueryAsync(getProductByCodeQuery)).QueryReturn;

            // 3º Step - Change Id if product existing
            var hasExistingProduct = (existingProduct?.Id ?? Guid.Empty) != Guid.Empty;
            if (hasExistingProduct)
                importedProduct.ChangeId(existingProduct.Id);

            /* Notify */
            if (!hasExistingProduct)
                _ = await Bus.SendEventAsync(await _productWasImportedEventFactory.CreateAsync(importedProduct));
            else
                _ = await Bus.SendEventAsync(await _productWasUpdatedEventFactory.CreateAsync(importedProduct));

            return importedProduct;
        }
    }
}

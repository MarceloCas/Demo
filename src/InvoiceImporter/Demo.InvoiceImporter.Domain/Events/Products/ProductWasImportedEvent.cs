using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Events.Products.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Events.Products
{
    public class ProductWasImportedEvent
        : Event
    {
        public Product Product { get; protected set; }

        protected ProductWasImportedEvent() { }

        #region Factories
        public class ProductWasImportedEventFactory
            : FactoryBase<ProductWasImportedEvent>,
            IProductWasImportedEventFactory
        {
            public ProductWasImportedEventFactory(
                IGlobalizationConfig globalizationConfig
                ) : base(globalizationConfig)
            {
            }

            public override async Task<ProductWasImportedEvent> CreateAsync()
            {
                return await Task.FromResult(new ProductWasImportedEvent());
            }

            public async Task<ProductWasImportedEvent> CreateAsync(Product parameter)
            {
                var productWasImportedEvent = await CreateAsync();

                productWasImportedEvent.Product = parameter;

                return productWasImportedEvent;
            }
        }
        #endregion
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Events.Products.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Events.Products
{
    public class ProductWasUpdatedEvent
        : Event
    {
        public Product Product { get; protected set; }

        protected ProductWasUpdatedEvent() { }

        #region Factories
        public class ProductWasUpdatedEventFactory
            : FactoryBase<ProductWasUpdatedEvent>,
            IProductWasUpdatedEventFactory
        {
            public ProductWasUpdatedEventFactory(
                IGlobalizationConfig globalizationConfig
                ) : base(globalizationConfig)
            {
            }

            public override async Task<ProductWasUpdatedEvent> CreateAsync()
            {
                return await Task.FromResult(new ProductWasUpdatedEvent());
            }

            public async Task<ProductWasUpdatedEvent> CreateAsync(Product parameter)
            {
                var productWasUpdatedEvent = await CreateAsync();

                productWasUpdatedEvent.Product = parameter;

                return productWasUpdatedEvent;
            }
        }
        #endregion
    }
}

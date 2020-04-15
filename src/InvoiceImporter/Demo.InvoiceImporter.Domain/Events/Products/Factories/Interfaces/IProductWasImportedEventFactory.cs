using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;

namespace Demo.InvoiceImporter.Domain.Events.Products.Factories.Interfaces
{
    public interface IProductWasImportedEventFactory
        : IFactoryWithParameters<ProductWasImportedEvent, Product>
    {
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces
{
    public interface IProductFactory
        : IFactory<Product>
    {
    }
}

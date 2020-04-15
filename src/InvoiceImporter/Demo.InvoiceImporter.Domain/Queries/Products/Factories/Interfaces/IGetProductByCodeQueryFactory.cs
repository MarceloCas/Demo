using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;

namespace Demo.InvoiceImporter.Domain.Queries.Products.Factories.Interfaces
{
    public interface IGetProductByCodeQueryFactory
        : IFactory<GetProductByCodeQuery>
    {
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;

namespace Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces
{
    public interface IGetCustomerByGovernamentalDocumentNumberQueryFactory
        : IFactory<GetCustomerByGovernamentalDocumentNumberQuery>
    {
    }
}

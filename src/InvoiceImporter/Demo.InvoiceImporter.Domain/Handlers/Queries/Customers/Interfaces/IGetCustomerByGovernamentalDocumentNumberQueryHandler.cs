using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers;

namespace Demo.InvoiceImporter.Domain.Handlers.Queries.Customers.Interfaces
{
    public interface IGetCustomerByGovernamentalDocumentNumberQueryHandler
        : IQueryHandler<GetCustomerByGovernamentalDocumentNumberQuery>
    {
    }
}

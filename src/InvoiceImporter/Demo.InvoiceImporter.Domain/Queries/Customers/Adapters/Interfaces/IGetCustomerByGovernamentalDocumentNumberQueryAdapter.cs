using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;

namespace Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces
{
    public interface IGetCustomerByGovernamentalDocumentNumberQueryAdapter
        : IAdapter<GetCustomerByGovernamentalDocumentNumberQuery, Customer>
    {

    }
}

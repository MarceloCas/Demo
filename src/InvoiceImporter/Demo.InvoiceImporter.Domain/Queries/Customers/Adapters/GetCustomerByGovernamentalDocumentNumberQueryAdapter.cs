using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Queries.Customers.Adapters
{
    public class GetCustomerByGovernamentalDocumentNumberQueryAdapter
        : AdapterBase,
        IGetCustomerByGovernamentalDocumentNumberQueryAdapter
    {
        public async Task<GetCustomerByGovernamentalDocumentNumberQuery> AdapteeAsync(Customer source, GetCustomerByGovernamentalDocumentNumberQuery to)
        {
            to.SetGovernamentalDocumentNumber(source.GovernamentalDocumentNumber);

            return await Task.FromResult(to);
        }
    }
}

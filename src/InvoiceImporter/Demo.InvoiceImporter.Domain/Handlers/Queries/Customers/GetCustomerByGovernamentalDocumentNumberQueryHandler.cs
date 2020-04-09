using Demo.Core.Domain.Handlers.Queries;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.Handlers.Queries.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Handlers.Queries.Customers
{
    public class GetCustomerByGovernamentalDocumentNumberQueryHandler
        : QueryHandlerBase<GetCustomerByGovernamentalDocumentNumberQuery>,
        IGetCustomerByGovernamentalDocumentNumberQueryHandler
    {
        protected override QueryHandler<GetCustomerByGovernamentalDocumentNumberQuery> GetQueryHandler()
        {
            return async query =>
            {
                return await Task.FromResult(true);
            };
        }
    }
}

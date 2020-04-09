using Demo.Core.Domain.Handlers.Queries;
using Demo.Core.Domain.Queries.DomainModelsBase;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Handlers.Queries.Customers.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Handlers.Queries.Customers
{
    public class GetDomainModelByIdQueryHandler
        : QueryHandlerBase<GetDomainModelByIdQuery<Customer>>,
        IGetDomainModelByIdQueryHandler

    {
        protected override QueryHandler<GetDomainModelByIdQuery<Customer>> GetQueryHandler()
        {
            return async query =>
            {
                return await Task.FromResult(true);
            };
        }
    }
}

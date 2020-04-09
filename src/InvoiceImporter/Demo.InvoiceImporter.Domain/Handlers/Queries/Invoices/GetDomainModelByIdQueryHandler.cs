using Demo.Core.Domain.Handlers.Queries;
using Demo.Core.Domain.Queries.DomainModelsBase;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Handlers.Queries.Invoices.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Handlers.Queries.Invoices
{
    public class GetDomainModelByIdQueryHandler
        : QueryHandlerBase<GetDomainModelByIdQuery<Invoice>>,
        IGetDomainModelByIdQueryHandler
    {
        protected override QueryHandler<GetDomainModelByIdQuery<Invoice>> GetQueryHandler()
        {
            return async query =>
            {
                return await Task.FromResult(true);
            };
        }
    }
}

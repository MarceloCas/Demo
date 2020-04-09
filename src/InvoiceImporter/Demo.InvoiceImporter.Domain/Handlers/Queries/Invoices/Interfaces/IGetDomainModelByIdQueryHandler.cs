using Demo.Core.Domain.Queries.DomainModelsBase;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;

namespace Demo.InvoiceImporter.Domain.Handlers.Queries.Invoices.Interfaces
{
    public interface IGetDomainModelByIdQueryHandler
        : IQueryHandler<GetDomainModelByIdQuery<Invoice>>
    {
    }
}

using Demo.Core.Domain.Handlers.Queries;
using Demo.Core.Domain.Queries.DomainModelsBase;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Handlers.Queries.Invoices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Handlers.Queries.Invoices
{
    public class GetDomainModelByIdQueryHandler
        : QueryHandlerBase<GetDomainModelByIdQuery<Invoice>>,
        IGetDomainModelByIdQueryHandler

    {
        public override async Task<bool> HandleAsync(GetDomainModelByIdQuery<Invoice> query)
        {
            return await Task.FromResult(true);
        }
    }
}

using Demo.Core.Domain.Handlers.Queries;
using Demo.Core.Domain.Queries.DomainModelsBase;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Handlers.Queries.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Handlers.Queries.Customers
{
    public class GetDomainModelByIdQueryHandler
        : QueryHandlerBase<GetDomainModelByIdQuery<Customer>>,
        IGetDomainModelByIdQueryHandler

    {
        public override async Task<bool> HandleAsync(GetDomainModelByIdQuery<Customer> query)
        {
            return await Task.FromResult(true);
        }

    }
}

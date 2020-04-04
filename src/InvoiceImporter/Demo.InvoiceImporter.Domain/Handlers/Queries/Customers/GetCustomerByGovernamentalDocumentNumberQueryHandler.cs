using Demo.Core.Domain.Handlers.Queries;
using Demo.InvoiceImporter.Domain.Handlers.Queries.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Handlers.Queries.Customers
{
    public class GetCustomerByGovernamentalDocumentNumberQueryHandler
        : QueryHandlerBase<GetCustomerByGovernamentalDocumentNumberQuery>,
        IGetCustomerByGovernamentalDocumentNumberQueryHandler
    {
        public override async Task<bool> HandleAsync(GetCustomerByGovernamentalDocumentNumberQuery query)
        {
            return await Task.FromResult(false);
        }
    }
}

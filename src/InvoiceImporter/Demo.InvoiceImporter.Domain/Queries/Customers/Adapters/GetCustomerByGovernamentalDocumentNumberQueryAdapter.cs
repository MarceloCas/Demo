using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Queries.Customers.Adapters
{
    public class GetCustomerByGovernamentalDocumentNumberQueryAdapter
        : AdapterBase,
        IGetCustomerByGovernamentalDocumentNumberQueryAdapter
    {
        // Attributes
        private readonly IGetCustomerByGovernamentalDocumentNumberQueryFactory _getCustomerByGovernamentalDocumentNumberQueryFactory;

        // Constructors
        public GetCustomerByGovernamentalDocumentNumberQueryAdapter(
            IGetCustomerByGovernamentalDocumentNumberQueryFactory getCustomerByGovernamentalDocumentNumberQueryFactory)
        {
            _getCustomerByGovernamentalDocumentNumberQueryFactory = getCustomerByGovernamentalDocumentNumberQueryFactory;
        }

        public async Task<GetCustomerByGovernamentalDocumentNumberQuery> AdapteeAsync(Customer source)
        {
            var query = await _getCustomerByGovernamentalDocumentNumberQueryFactory.CreateAsync();
            query.SetGovernamentalDocumentNumber(source.GovernamentalDocumentNumber);

            return query;
        }
    }
}

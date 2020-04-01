using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Queries.Customers.Adapters
{
    public class GetCustomerByIdQueryAdapter
        : AdapterBase,
        IGetCustomerByIdQueryAdapter
    {
        // Attributes
        private readonly IGetCustomerByIdQueryFactory _getCustomerByIdQueryFactory;

        // Constructors
        public GetCustomerByIdQueryAdapter(IGetCustomerByIdQueryFactory getCustomerByIdQueryFactory)
        {
            _getCustomerByIdQueryFactory = getCustomerByIdQueryFactory;
        }

        // Public Methods
        public async Task<GetCustomerByIdQuery> AdapteeAsync(Customer source)
        {
            var query = await _getCustomerByIdQueryFactory.CreateAsync();
            query.SetCustomerId(source.Id);

            return query;
        }
    }
}

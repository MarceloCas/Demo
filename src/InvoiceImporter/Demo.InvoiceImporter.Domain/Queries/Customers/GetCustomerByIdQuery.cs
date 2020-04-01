using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Queries.Customers
{
    public class GetCustomerByIdQuery
        : Query<Customer>
    {
        // Properties
        public Guid CustomerId { get; protected set; }

        // Public Methods
        public void SetCustomerId(Guid id)
        {
            CustomerId = id;
        }

        // Constructors
        protected GetCustomerByIdQuery() { }

        // Factories
        public class GetCustomerByIdQueryFactory
            : FactoryBase<GetCustomerByIdQuery>,
            IGetCustomerByIdQueryFactory
        {
            public GetCustomerByIdQueryFactory(
                IGlobalizationConfig globalizationConfig
                ) : base(globalizationConfig)
            {

            }

            public override async Task<GetCustomerByIdQuery> CreateAsync()
            {
                return await Task.FromResult(new GetCustomerByIdQuery());
            }
        }
    }
}

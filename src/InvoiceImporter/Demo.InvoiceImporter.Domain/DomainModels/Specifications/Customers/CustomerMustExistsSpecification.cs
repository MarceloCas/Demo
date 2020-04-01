using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers
{
    public class CustomerMustExistsSpecification
        : SpecificationBase<Customer>,
        ICustomerMustExistsSpecification
    {
        private readonly IGetCustomerByIdQueryAdapter _getCustomerByIdQueryAdapter;

        public CustomerMustExistsSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig,
            IGetCustomerByIdQueryAdapter getCustomerByIdQueryAdapter
            ) : base(bus, globalizationConfig)
        {
            _getCustomerByIdQueryAdapter = getCustomerByIdQueryAdapter;
        }

        public override async Task<bool> IsSatisfiedByAsync(Customer entity)
        {
            var getCustomerByIdQuery = await _getCustomerByIdQueryAdapter.AdapteeAsync(entity);
            await Bus.SendQueryAsync(getCustomerByIdQuery);

            return (getCustomerByIdQuery.QueryReturn?.Id ?? Guid.Empty) != Guid.Empty;
        }
    }
}

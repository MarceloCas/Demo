using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers
{
    public class CustomerGovernamentalDocumentNumberMustBeUniqueSpecification
        : SpecificationBase<Customer>,
        ICustomerGovernamentalDocumentNumberMustBeUniqueSpecification
    {
        private readonly IGetCustomerByGovernamentalDocumentNumberQueryAdapter _getCustomerByGovernamentalDocumentNumberQueryAdapter;

        public CustomerGovernamentalDocumentNumberMustBeUniqueSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig,
            IGetCustomerByGovernamentalDocumentNumberQueryAdapter getCustomerByGovernamentalDocumentNumberQueryAdapter
            ) : base(bus, globalizationConfig)
        {
            _getCustomerByGovernamentalDocumentNumberQueryAdapter = getCustomerByGovernamentalDocumentNumberQueryAdapter;
        }

        public override async Task<bool> IsSatisfiedByAsync(Customer entity)
        {
            var query = await _getCustomerByGovernamentalDocumentNumberQueryAdapter.AdapteeAsync(entity);
            await Bus.SendQueryAsync(query);

            return (query.QueryReturn?.Id ?? Guid.Empty) == Guid.Empty;
        }
    }
}

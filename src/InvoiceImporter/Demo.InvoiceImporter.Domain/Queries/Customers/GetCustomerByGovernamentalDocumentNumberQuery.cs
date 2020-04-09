using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Queries.Customers
{
    public class GetCustomerByGovernamentalDocumentNumberQuery
        : Query<Customer>
    {
        // Properties
        public string GovernamentalDocumentNumber { get; protected set; }

        // Constructors
        protected GetCustomerByGovernamentalDocumentNumberQuery() { }

        // Public Methods
        public void SetGovernamentalDocumentNumber(string governamentalDocumentNumber)
        {
            GovernamentalDocumentNumber = governamentalDocumentNumber;
        }

        // Factories
        public class GetCustomerByGovernamentalDocumentNumberQueryFactory
            : FactoryBase<GetCustomerByGovernamentalDocumentNumberQuery>,
            IGetCustomerByGovernamentalDocumentNumberQueryFactory
        {
            public GetCustomerByGovernamentalDocumentNumberQueryFactory(
                IGlobalizationConfig globalizationConfig) 
                : base(globalizationConfig)
            {

            }

            public override async Task<GetCustomerByGovernamentalDocumentNumberQuery> CreateAsync()
            {
                return await Task.FromResult(new GetCustomerByGovernamentalDocumentNumberQuery());
            }
        }
    }
}

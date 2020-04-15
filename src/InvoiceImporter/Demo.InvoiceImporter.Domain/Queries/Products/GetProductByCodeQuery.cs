using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Queries.Products.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Queries.Products
{
    public class GetProductByCodeQuery
        : Query<Product>
    {
        // Properties
        public string Code { get; protected set; }

        // Constructors
        protected GetProductByCodeQuery() { }

        // Public Methods
        public void SetCode(string code)
        {
            Code = code;
        }

        // Factories
        public class GetProductByCodeQueryFactory
            : FactoryBase<GetProductByCodeQuery>,
            IGetProductByCodeQueryFactory
        {
            public GetProductByCodeQueryFactory(
                IGlobalizationConfig globalizationConfig
                ) : base(globalizationConfig)
            {

            }

            public override async Task<GetProductByCodeQuery> CreateAsync()
            {
                return await Task.FromResult(new GetProductByCodeQuery());
            }
        }
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Products
{
    public class ProductMustHaveCodeSpecification
        : SpecificationBase<Product>,
        IProductMustHaveCodeSpecification
    {
        public ProductMustHaveCodeSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(Product entity)
        {
            return await Task.FromResult(!string.IsNullOrWhiteSpace(entity?.Code));
        }
    }
}

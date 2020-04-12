using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Products.Interfaces
{
    public interface IProductMustHaveCodeSpecification
        : ISpecification<Product>
    {
    }
}

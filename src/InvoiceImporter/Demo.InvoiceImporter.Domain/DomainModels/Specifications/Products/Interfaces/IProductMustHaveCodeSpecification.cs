using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Products.Interfaces
{
    public interface IProductMustHaveCodeSpecification
        : ISpecification<Product>
    {
    }
}

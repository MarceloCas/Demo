using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.Products.Interfaces
{
    public interface IProductIsValidForImportValidation
        : IValidator<Product>
    {
    }
}

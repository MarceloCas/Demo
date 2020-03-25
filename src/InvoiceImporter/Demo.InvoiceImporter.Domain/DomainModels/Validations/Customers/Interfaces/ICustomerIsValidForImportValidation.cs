using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces
{
    public interface ICustomerIsValidForImportValidation
        : IValidator<Customer>
    {
    }
}

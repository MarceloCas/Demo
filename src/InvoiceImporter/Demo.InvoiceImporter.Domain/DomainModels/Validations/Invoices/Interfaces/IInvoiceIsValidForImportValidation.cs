using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.Invoices.Interfaces
{
    public interface IInvoiceIsValidForImportValidation
        : IValidator<Invoice>
    {
    }
}

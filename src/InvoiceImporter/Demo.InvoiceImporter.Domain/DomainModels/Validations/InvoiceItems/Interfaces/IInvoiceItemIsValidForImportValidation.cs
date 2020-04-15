using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.InvoiceItems.Interfaces
{
    public interface IInvoiceItemIsValidForImportValidation
        : IValidator<InvoiceItem>
    {
    }
}

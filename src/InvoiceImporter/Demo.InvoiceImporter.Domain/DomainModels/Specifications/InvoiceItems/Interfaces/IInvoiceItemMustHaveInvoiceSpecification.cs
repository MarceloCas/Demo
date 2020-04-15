using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.InvoiceItems.Interfaces
{
    public interface IInvoiceItemMustHaveInvoiceSpecification
        : ISpecification<InvoiceItem>
    {
    }
}

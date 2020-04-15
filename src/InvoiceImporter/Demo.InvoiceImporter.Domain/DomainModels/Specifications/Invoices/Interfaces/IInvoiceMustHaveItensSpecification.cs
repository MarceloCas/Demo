using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices.Interfaces
{
    public interface IInvoiceMustHaveItensSpecification
        : ISpecification<Invoice>
    {
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces
{
    public interface ICustomerMustHaveGovernamentalDocumentNumberSpecification
        : ISpecification<Customer>
    {
    }
}

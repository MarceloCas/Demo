using Demo.Core.Domain.Repositories.Base.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;

namespace Demo.InvoiceImporter.Domain.Repositories.Interfaces
{
    public interface ICustomerRepository
        : IAuditableRepository<Customer>
    {
    }
}

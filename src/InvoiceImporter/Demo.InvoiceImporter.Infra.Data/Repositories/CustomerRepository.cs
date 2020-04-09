using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Infra.Data.Repositories
{
    public class CustomerRepository
        : ICustomerRepository
    {
        public Task<Customer> AddAsync(Customer domainModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetByCreationDateOrModificationDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetByCreationInfo(string creationUser, DateTime creationDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetByCreationUserOrModificationUser(string user)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetByModificationInfo(string modificationUser, DateTime modificationDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetByTenantCodeAsync(string tenantCode)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> RemoveAsync(Customer domainModel)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateAsync(Customer domainModel)
        {
            throw new NotImplementedException();
        }
    }
}

using Demo.Core.Domain.DomainModels.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.Core.Domain.Repositories.Base.Interfaces
{
    public interface IRepository<TDomainModel>
        : IDisposable
        where TDomainModel : IDomainModel
    {
        Task<TDomainModel> AddAsync(TDomainModel domainModel);
        Task<TDomainModel> UpdateAsync(TDomainModel domainModel);
        Task<TDomainModel> RemoveAsync(TDomainModel domainModel);
        Task<TDomainModel> GetByIdAsync(Guid id);

        Task<IEnumerable<TDomainModel>> GetAllAsync();
        Task<IEnumerable<TDomainModel>> GetByTenantCodeAsync(string tenantCode);
        Task<IEnumerable<TDomainModel>> FindAsync(Expression<Func<TDomainModel, bool>> expression);
    }
}

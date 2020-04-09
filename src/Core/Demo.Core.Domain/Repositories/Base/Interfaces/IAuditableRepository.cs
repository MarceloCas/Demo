using Demo.Core.Domain.DomainModels.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Core.Domain.Repositories.Base.Interfaces
{
    public interface IAuditableRepository<TAuditableDomainModel>
        : IRepository<TAuditableDomainModel>
        where TAuditableDomainModel : IAuditableDomainModel
    {
        Task<IEnumerable<TAuditableDomainModel>> GetByCreationInfo(string creationUser, DateTime creationDate);
        Task<IEnumerable<TAuditableDomainModel>> GetByModificationInfo(string modificationUser, DateTime modificationDate);
        Task<IEnumerable<TAuditableDomainModel>> GetByCreationUserOrModificationUser(string user);
        Task<IEnumerable<TAuditableDomainModel>> GetByCreationDateOrModificationDate(DateTime date);

    }
}

using Demo.Core.Domain.DomainModels.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.Repositories.Base.Interfaces
{
    public interface IAuditableRepository<TAuditableDomainModel>
        : IRepository<TAuditableDomainModel>
        where TAuditableDomainModel : IAuditableDomainModel
    {
    }
}

using Demo.Core.Domain.DomainModels.Base.Interfaces;
using System;

namespace Demo.Core.Domain.DomainServices.Base.Interfaces
{
    public interface IDomainService<TDomainModel>
        : IDisposable
        where TDomainModel : IDomainModel
    {

    }
}

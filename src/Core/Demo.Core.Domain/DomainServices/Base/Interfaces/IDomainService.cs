using Demo.Core.Domain.DomainModels.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.DomainServices.Base.Interfaces
{
    public interface IDomainService<TDomainModel>
        : IDisposable
        where TDomainModel : IDomainModel
    {

    }
}

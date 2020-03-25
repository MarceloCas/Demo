using Demo.Core.Domain.DomainModels.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.DomainModels.Interfaces
{
    public interface IProduct
        : IAuditableDomainModel
    {
        string Name { get; }
        string Code { get; }
    }
}

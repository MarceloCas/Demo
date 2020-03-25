using Demo.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.DomainModels.Base.Interfaces
{
    public interface IDomainModel
        : IDisposable
    {
        Guid Id { get; }
        string TenantCode { get; }
    }
}

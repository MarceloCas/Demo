using System;

namespace Demo.Core.Domain.DomainModels.Base.Interfaces
{
    public interface IDomainModel
        : IDisposable
    {
        Guid Id { get; }
        string TenantCode { get; }
    }
}

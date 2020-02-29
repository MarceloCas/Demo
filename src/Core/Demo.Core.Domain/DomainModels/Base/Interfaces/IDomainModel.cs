using Demo.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.DomainModels.Base.Interfaces
{
    public interface IDomainModel
        : IDisposable
    {
        public Guid Id { get; }
        public string TenantCode { get; }
    }
}

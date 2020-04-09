using System;

namespace Demo.Core.Domain.DomainModels.Base.Interfaces
{
    public interface IAuditableDomainModel
        : IDomainModel
    {
        string CreationUser { get; }
        DateTime CreationDate { get; }
        string ModificationUser { get; }
        DateTime ModificationDate { get; }
    }
}

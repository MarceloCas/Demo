using Demo.Core.Domain.DomainModels.Base.Interfaces;

namespace Demo.Core.Domain.DomainModels.Interfaces
{
    public interface ICustomer
        : IAuditableDomainModel
    {
        string Name { get; }
    }
}

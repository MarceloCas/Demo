using Demo.Core.Domain.DomainModels.Base.Interfaces;

namespace Demo.Core.Domain.DomainModels.Interfaces
{
    public interface IProduct
        : IAuditableDomainModel
    {
        string Name { get; }
        string Code { get; }
    }
}

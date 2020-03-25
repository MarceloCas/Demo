using Demo.Core.Domain.DomainModels.Base.Interfaces;

namespace Demo.Core.Domain.DomainModels.Interfaces
{
    public interface IInvoiceItem<TProduct>
        : IAuditableDomainModel
        where TProduct : IProduct
    {
        TProduct Product { get; }
    }
}

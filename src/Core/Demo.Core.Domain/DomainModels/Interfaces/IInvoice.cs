using Demo.Core.Domain.DomainModels.Base.Interfaces;
using System.Collections.Generic;

namespace Demo.Core.Domain.DomainModels.Interfaces
{
    public interface IInvoice<TCustomer, TProduct, TInvoiceItem>
        : IAuditableDomainModel
        where TCustomer : ICustomer
        where TProduct : IProduct
        where TInvoiceItem : IInvoiceItem<TProduct>
    {
        string Code { get; }
        TCustomer Customer { get; }
        ICollection<TInvoiceItem> InvoiceItemCollection { get; }
    }
}

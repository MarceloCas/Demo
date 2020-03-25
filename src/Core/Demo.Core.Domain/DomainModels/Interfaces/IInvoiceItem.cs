using Demo.Core.Domain.DomainModels.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.DomainModels.Interfaces
{
    public interface IInvoiceItem<TProduct>
        : IAuditableDomainModel
        where TProduct : IProduct
    {
        TProduct Product { get; }
    }
}

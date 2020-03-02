using Demo.Core.Domain.DomainServices.Base.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainServices.Interfaces
{
    public interface IProductDomainService
        : IDomainService<Product>
    {
    }
}

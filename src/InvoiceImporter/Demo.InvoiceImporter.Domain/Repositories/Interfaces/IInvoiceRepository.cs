using Demo.Core.Domain.Repositories.Base;
using Demo.InvoiceImporter.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.Repositories.Interfaces
{
    public interface IInvoiceRepository
        : IRepository<Invoice>
    {
    }
}

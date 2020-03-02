using Demo.Core.Domain.Repositories.Base;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class InvoiceDomainService
        : DomainServiceBase<Invoice>,
        IInvoiceDomainService
    {
        public InvoiceDomainService(IInvoiceRepository repository) 
            : base(repository)
        {
        }
    }
}

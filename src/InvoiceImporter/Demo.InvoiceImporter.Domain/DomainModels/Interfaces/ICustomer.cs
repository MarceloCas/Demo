using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainModels.Interfaces
{
    public interface ICustomer
        : Core.Domain.DomainModels.Interfaces.ICustomer
    {
        string GovernamentalDocumentNumber { get; }
    }
}

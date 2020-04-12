using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.Events.Invoices.Factories.Interfaces
{
    public interface IInvoiceWasImportedEventFactory
        : IFactoryWithParameters<InvoiceWasImportedEvent, Invoice>
    {
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;

namespace Demo.InvoiceImporter.Domain.Events.Invoices.Factories.Interfaces
{
    public interface IInvoiceWasImportedEventFactory
        : IFactoryWithParameters<InvoiceWasImportedEvent, Invoice>
    {
    }
}

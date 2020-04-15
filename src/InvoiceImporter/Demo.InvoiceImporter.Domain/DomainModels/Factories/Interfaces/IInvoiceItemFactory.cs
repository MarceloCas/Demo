using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces
{
    public interface IInvoiceItemFactory
        : IFactory<InvoiceItem>,
        IFactoryWithParameters<InvoiceItem, Domain.Commands.Invoices.ImportInvoice.InvoiceItem>
    {
    }
}

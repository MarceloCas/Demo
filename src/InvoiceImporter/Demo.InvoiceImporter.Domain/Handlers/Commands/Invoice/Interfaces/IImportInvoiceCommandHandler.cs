using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.Commands.Invoices;

namespace Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice.Interfaces
{
    public interface IImportInvoiceCommandHandler
        : ICommandHandler<ImportInvoiceCommand>
    {

    }
}

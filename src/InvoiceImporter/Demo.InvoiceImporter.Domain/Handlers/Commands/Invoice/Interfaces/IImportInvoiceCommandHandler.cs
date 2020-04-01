using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.Commands.Invoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice.Interfaces
{
    public interface IImportInvoiceCommandHandler
        : ICommandHandler<ImportInvoiceCommand>
    {

    }
}

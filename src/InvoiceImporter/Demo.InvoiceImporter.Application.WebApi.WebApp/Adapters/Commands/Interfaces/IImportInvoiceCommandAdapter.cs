using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands.Interfaces
{
    public interface IImportInvoiceCommandAdapter
        : IAdapter<ImportInvoiceCommand, InvoiceViewModel>
    {
    }
}

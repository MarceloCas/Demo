using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter.Interfaces;
using Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice;
using System.Collections.Generic;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands.Interfaces
{
    public interface IImportInvoiceCommandAdapter
        : IAdapter<List<ImportInvoiceCommand>, ViewModels.ImportInvoiceFromXMLFile.ImportInvoiceFromXMLFileViewModel>,
        IAdapter<List<ImportInvoiceCommand>, ViewModels.ImportInvoiceFromCSVFile.ImportInvoiceFromCSVFileViewModel>
    {
    }
}

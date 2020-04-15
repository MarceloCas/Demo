using Demo.Core.Application.AppServices.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice;
using System;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices
{
    public class ImportInvoiceAppService
        : AppServiceBase,
        IImportInvoiceAppService
    {
        public ImportInvoiceAppService(IBus bus) 
            : base(bus)
        {
        }

        public Task<bool> ImportInvoiceFromCSV(ImportInvoiceFromCSVFileViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ImportInvoiceFromXML(ImportInvoiceFromXMLFileViewModel viewModel)
        {
            var importInvoiceCommand = new ImportInvoiceCommand();

            var commandReturn = await Bus.SendCommandAsync(importInvoiceCommand);

            return await Task.FromResult(commandReturn);
        }
    }
}

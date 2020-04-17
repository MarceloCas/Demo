using Demo.Core.Application.AppServices.Base;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands.Interfaces;
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
        private readonly IImportInvoiceCommandAdapter _importInvoiceCommandAdapter;

        public ImportInvoiceAppService(
            IBus bus,
            IGlobalizationConfig globalizationConfig,
            ITenantInfoValueObjectFactory tenantInfoValueObjectFactory,
            IImportInvoiceCommandAdapter importInvoiceCommandAdapter
            ) : base(bus, globalizationConfig, tenantInfoValueObjectFactory)
        {
            _importInvoiceCommandAdapter = importInvoiceCommandAdapter;
        }

        public Task<bool> ImportInvoiceFromCSV(ImportInvoiceFromCSVFileViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ImportInvoiceFromXML(ImportInvoiceFromXMLFileViewModel viewModel)
        {
            foreach (var invoiceViewModel in viewModel.InvoiceViewModelCollection)
            {
                var importInvoiceCommand = await _importInvoiceCommandAdapter.AdapteeAsync(
                    invoiceViewModel, 
                    new ImportInvoiceCommand());

                await Bus.SendCommandAsync(importInvoiceCommand);
            }

            return await Task.FromResult(true);
        }
    }
}

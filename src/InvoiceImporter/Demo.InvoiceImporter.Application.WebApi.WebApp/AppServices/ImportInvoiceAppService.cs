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
using System.Collections.Generic;
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

        public async Task<bool> ImportInvoiceFromCSV(ImportInvoiceFromCSVFileViewModel viewModel)
        {
            var result = true;

            var importInvoiceCommandCollection = await _importInvoiceCommandAdapter.AdapteeAsync(
                viewModel,
                new List<ImportInvoiceCommand>());

            foreach (var importInvoiceCommand in importInvoiceCommandCollection)
            {
                if (!(await Bus.SendCommandAsync(importInvoiceCommand)))
                    result = false;
            }

            return await Task.FromResult(result);
        }

        public async Task<bool> ImportInvoiceFromXML(ImportInvoiceFromXMLFileViewModel viewModel)
        {
            var result = true;

            var importInvoiceCommandCollection = await _importInvoiceCommandAdapter.AdapteeAsync(
                viewModel,
                new List<ImportInvoiceCommand>());

            foreach (var importInvoiceCommand in importInvoiceCommandCollection)
            {
                if (!(await Bus.SendCommandAsync(importInvoiceCommand)))
                    result = false;
            }

            return await Task.FromResult(result);
        }
    }
}

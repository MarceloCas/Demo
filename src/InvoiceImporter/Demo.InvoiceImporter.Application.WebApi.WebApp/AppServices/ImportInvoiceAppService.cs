using Demo.Core.Application.AppServices.Base;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromCSVFiles.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromXMLFile.Interfaces;
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
        private readonly IImportInvoiceFromXMLFileViewModelIsValidToImportValidation _importInvoiceFromXMLFileViewModelIsValidToImportValidation;
        private readonly IImportInvoiceFromCSVFileViewModelIsValidToImportValidation _importInvoiceFromCSVFileViewModelIsValidToImportValidation;

        private readonly IImportInvoiceCommandAdapter _importInvoiceCommandAdapter;

        public ImportInvoiceAppService(
            IBus bus,
            IGlobalizationConfig globalizationConfig,
            ITenantInfoValueObjectFactory tenantInfoValueObjectFactory,
            IImportInvoiceCommandAdapter importInvoiceCommandAdapter,
            IImportInvoiceFromXMLFileViewModelIsValidToImportValidation importInvoiceFromXMLFileViewModelIsValidToImportValidation,
            IImportInvoiceFromCSVFileViewModelIsValidToImportValidation importInvoiceFromCSVFileViewModelIsValidToImportValidation
            ) : base(bus, globalizationConfig, tenantInfoValueObjectFactory)
        {
            _importInvoiceFromXMLFileViewModelIsValidToImportValidation = importInvoiceFromXMLFileViewModelIsValidToImportValidation;
            _importInvoiceFromCSVFileViewModelIsValidToImportValidation = importInvoiceFromCSVFileViewModelIsValidToImportValidation;

            _importInvoiceCommandAdapter = importInvoiceCommandAdapter;
        }

        public async Task<bool> ImportInvoiceFromXML(ImportInvoiceFromXMLFileViewModel viewModel)
        {
            /* Validate */
            if (await ValidateAsync(viewModel, _importInvoiceFromXMLFileViewModelIsValidToImportValidation) == false)
                return await Task.FromResult(false);

            /* Process */
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
        public async Task<bool> ImportInvoiceFromCSV(ImportInvoiceFromCSVFileViewModel viewModel)
        {
            /* Validate */
            if (await ValidateAsync(viewModel, _importInvoiceFromCSVFileViewModelIsValidToImportValidation) == false)
                return await Task.FromResult(false);

            /* Process */
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

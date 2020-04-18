using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromCSVFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromCSVFiles
{
    public class ImportInvoiceFromCSVFileViewModelIsValidToImportValidation
        : Validator<ImportInvoiceFromCSVFileViewModel>,
        IImportInvoiceFromCSVFileViewModelIsValidToImportValidation
    {
        protected override async Task<bool> ExecutePostValidateAsync(ImportInvoiceFromCSVFileViewModel entity, ValidationResult validationResult)
        {
            return await Task.FromResult(true);
        }
    }
}

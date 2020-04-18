using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromXMLFile.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromXMLFile
{
    public class ImportInvoiceFromXMLFileViewModelIsValidToImportValidation
        : Validator<ImportInvoiceFromXMLFileViewModel>,
        IImportInvoiceFromXMLFileViewModelIsValidToImportValidation
    {
        protected override async Task<bool> ExecutePostValidateAsync(ImportInvoiceFromXMLFileViewModel entity, ValidationResult validationResult)
        {
            return await Task.FromResult(true);
        }
    }
}

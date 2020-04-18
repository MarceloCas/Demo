using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromCSVFiles.Interfaces
{
    public interface IImportInvoiceFromCSVFileViewModelIsValidToImportValidation
        : IValidator<ImportInvoiceFromCSVFileViewModel>
    {
    }
}

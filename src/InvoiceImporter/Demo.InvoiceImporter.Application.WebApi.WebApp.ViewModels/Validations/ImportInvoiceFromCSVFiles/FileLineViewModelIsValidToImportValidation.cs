using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromCSVFiles.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromCSVFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromCSVFiles
{
    public class FileLineViewModelIsValidToImportValidation
        : Validator<FileLineViewModel>,
        IFileLineViewModelIsValidToImportValidation
    {
        public FileLineViewModelIsValidToImportValidation(
            IInvoiceCSVLineMustHaveCustomerGovernamentalDocumentNumberSpecification invoiceCSVLineMustHaveCustomerGovernamentalDocumentNumberSpecification,
            IInvoiceCSVLineMustHaveCustomerNameSpecification invoiceCSVLineMustHaveCustomerNameSpecification,
            IInvoiceCSVLineMustHaveInvoiceCodeSpecification invoiceCSVLineMustHaveInvoiceCodeSpecification,
            IInvoiceCSVLineMustHaveProductCodeSpecification invoiceCSVLineMustHaveProductCodeSpecification,
            IInvoiceCSVLineMustHaveProductNameSpecification invoiceCSVLineMustHaveProductNameSpecification
            )
        {
            AddSpecification(invoiceCSVLineMustHaveCustomerGovernamentalDocumentNumberSpecification);
            AddSpecification(invoiceCSVLineMustHaveCustomerNameSpecification);
            AddSpecification(invoiceCSVLineMustHaveInvoiceCodeSpecification);
            AddSpecification(invoiceCSVLineMustHaveProductCodeSpecification);
            AddSpecification(invoiceCSVLineMustHaveProductNameSpecification);
        }

        protected override async Task<bool> ExecutePostValidateAsync(FileLineViewModel entity, ValidationResult validationResult)
        {
            return await Task.FromResult(true);
        }
    }
}

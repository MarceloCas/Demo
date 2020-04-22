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
    public class ImportInvoiceFromCSVFileViewModelIsValidToImportValidation
        : Validator<ImportInvoiceFromCSVFileViewModel>,
        IImportInvoiceFromCSVFileViewModelIsValidToImportValidation
    {
        private readonly IFileLineViewModelIsValidToImportValidation _fileLineViewModelIsValidToImportValidation;

        public ImportInvoiceFromCSVFileViewModelIsValidToImportValidation(
            IInvoiceCSVFileMustHaveOneClientPerInvoiceCodeSpecification invoiceCSVFileMustHaveOneClientPerInvoiceCodeSpecification,
            IInvoiceCSVFileMustHaveOneDatePerInvoiceCodeSpecification invoiceCSVFileMustHaveOneDatePerInvoiceCodeSpecification,
            IInvoiceCSVFileMustHaveOneProductPerInvoiceCodeSpecification invoiceCSVFileMustHaveOneProductPerInvoiceCodeSpecification,
            IInvoiceCSVFileMustHaveOneSequencesPerInvoiceCodeSpecification invoiceCSVFileMustHaveOneSequencesPerInvoiceCodeSpecification,
            IFileLineViewModelIsValidToImportValidation fileLineViewModelIsValidToImportValidation
            )
        {
            AddSpecification(invoiceCSVFileMustHaveOneClientPerInvoiceCodeSpecification);
            AddSpecification(invoiceCSVFileMustHaveOneDatePerInvoiceCodeSpecification);
            AddSpecification(invoiceCSVFileMustHaveOneProductPerInvoiceCodeSpecification);
            AddSpecification(invoiceCSVFileMustHaveOneSequencesPerInvoiceCodeSpecification);

            _fileLineViewModelIsValidToImportValidation = fileLineViewModelIsValidToImportValidation;
        }

        protected override async Task<bool> ExecutePostValidateAsync(ImportInvoiceFromCSVFileViewModel entity, ValidationResult validationResult)
        {
            foreach (var fileLine in entity?.FileLineCollection)
            {
                var invoiceItemValdiationResult = await _fileLineViewModelIsValidToImportValidation.ValidateAsync(fileLine);
                if (!invoiceItemValdiationResult.IsValid)
                    validationResult.AddFromAnotherValidationResult(invoiceItemValdiationResult);
            }

            return await Task.FromResult(true);
        }
    }
}

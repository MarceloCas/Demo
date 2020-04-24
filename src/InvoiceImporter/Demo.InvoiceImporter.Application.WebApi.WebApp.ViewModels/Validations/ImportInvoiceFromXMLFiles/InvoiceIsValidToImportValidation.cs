using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromXMLFiles.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromXMLFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromXMLFiles
{
    public class InvoiceIsValidToImportValidation
        : Validator<InvoiceViewModel>,
        IInvoiceIsValidToImportValidation
    {
        private readonly IInvoiceItemIsValidToImportValidation _invoiceItemIsValidToImportValidation;

        public InvoiceIsValidToImportValidation(
            IInvoiceMustHaveCodeSpecification invoiceMustHaveCodeSpecification,
            IInvoiceMustHaveCustomerSpecification invoiceMustHaveCustomerSpecification,
            IInvoiceMustHaveDateSpecification invoiceMustHaveDateSpecification,
            IInvoiceMustHaveItensSpecification invoiceMustHaveItensSpecification,
            IInvoiceMustHaveUniqueSequencesSpecification invoiceMustHaveUniqueSequencesSpecification,

            IInvoiceItemIsValidToImportValidation invoiceItemIsValidToImportValidation
            )
        {
            AddSpecification(invoiceMustHaveCodeSpecification);
            AddSpecification(invoiceMustHaveCustomerSpecification);
            AddSpecification(invoiceMustHaveDateSpecification);
            AddSpecification(invoiceMustHaveItensSpecification);
            AddSpecification(invoiceMustHaveUniqueSequencesSpecification);

            _invoiceItemIsValidToImportValidation = invoiceItemIsValidToImportValidation;
        }

        protected override async Task<bool> ExecutePostValidateAsync(InvoiceViewModel entity, ValidationResult validationResult)
        {
            if (entity?.InvoiceItemCollection != null)
                foreach (var invoiceItem in entity.InvoiceItemCollection)
                {
                    var invoiceItemValidationResult = await _invoiceItemIsValidToImportValidation.ValidateAsync(invoiceItem);
                    if (!invoiceItemValidationResult.IsValid)
                        validationResult.AddFromAnotherValidationResult(invoiceItemValidationResult);
                }

            return await Task.FromResult(true);
        }
    }
}

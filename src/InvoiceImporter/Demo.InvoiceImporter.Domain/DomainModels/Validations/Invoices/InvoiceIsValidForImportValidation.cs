using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.DomainModels.Base.Validations.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.InvoiceItems.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.InvoiceItems.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Invoices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.Invoices
{
    public class InvoiceIsValidForImportValidation
        : DomainModelValidatorBase<Invoice>,
        IInvoiceIsValidForImportValidation
    {
        private readonly IInvoiceItemIsValidForImportValidation _invoiceItemIsValidForImportValidation;

        public InvoiceIsValidForImportValidation(
            IDomainModelMustExistsSpecification domainModelMustExistsSpecification,
            IDomainModelMustHaveCreationDateSpecification domainModelMustHaveCreationDateSpecification,
            IDomainModelMustHaveCreationUserSpecification domainModelMustHaveCreationUserSpecification,
            IDomainModelMustHaveIdSpecification domainModelMustHaveIdSpecification,
            IDomainModelMustHaveModificationDateGreaterThanCreationDateSpecification domainModelMustHaveModificationDateGreaterThanCreationDateSpecification,
            IDomainModelMustHaveModificationDateSpecification domainModelMustHaveModificationDateSpecification,
            IDomainModelMustHaveModificationUserSpecification domainModelMustHaveModificationUserSpecification,
            IDomainModelMustHaveTenantCodeSpecification domainModelMustHaveTenantCodeSpecification,
            IDomainModelMustHaveTenantCodeWithValidLengthSpecification domainModelMustHaveTenantCodeWithValidLengthSpecification,
            IDomainModelMustNotExistsSpecification domainModelMustNotExistsSpecification,

            // Invoices
            IInvoiceMustHaveCodeSpecification invoiceMustHaveCodeSpecification,
            IInvoiceMustHaveCodeWithValidLengthSpecification invoiceMustHaveCodeWithValidLengthSpecification,
            IInvoiceMustHaveCustomerSpecification invoiceMustHaveCustomerSpecification,
            IInvoiceMustHaveItensSpecification invoiceMustHaveItensSpecification,
            IInvoiceMustHaveValidDateSpecification invoiceMustHaveValidDateSpecification,

            // InvoiceItem
            IInvoiceItemIsValidForImportValidation invoiceItemIsValidForImportValidation
            ) : base(domainModelMustExistsSpecification, domainModelMustHaveCreationDateSpecification, domainModelMustHaveCreationUserSpecification, domainModelMustHaveIdSpecification, domainModelMustHaveModificationDateGreaterThanCreationDateSpecification, domainModelMustHaveModificationDateSpecification, domainModelMustHaveModificationUserSpecification, domainModelMustHaveTenantCodeSpecification, domainModelMustHaveTenantCodeWithValidLengthSpecification, domainModelMustNotExistsSpecification)
        {
            _invoiceItemIsValidForImportValidation = invoiceItemIsValidForImportValidation;

            AddMustHaveTenantCodeSpecification();
            AddMustHaveTenantCodeWithValidLengthSpecification();

            AddSpecification(invoiceMustHaveCodeSpecification);
            AddSpecification(invoiceMustHaveCodeWithValidLengthSpecification);
            AddSpecification(invoiceMustHaveCustomerSpecification);
            AddSpecification(invoiceMustHaveItensSpecification);
            AddSpecification(invoiceMustHaveValidDateSpecification);
        }

        protected override async Task<bool> ExecutePostValidateAsync(Invoice entity, ValidationResult validationResult)
        {
            foreach (var invoiceItem in entity?.InvoiceItemCollection)
            {
                var invoiceItemValdiationResult = await _invoiceItemIsValidForImportValidation.ValidateAsync(invoiceItem);
                if (!invoiceItemValdiationResult.IsValid)
                    validationResult.AddFromAnotherValidationResult(invoiceItemValdiationResult);
            }

            return await Task.FromResult(true);
        }
    }
}

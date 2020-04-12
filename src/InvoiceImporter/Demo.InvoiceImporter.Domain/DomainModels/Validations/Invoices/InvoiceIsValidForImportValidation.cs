using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.DomainModels.Base.Validations.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices.Interfaces;
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

            IInvoiceMustHaveCodeSpecification invoiceMustHaveCodeSpecification,
            IInvoiceMustHaveCodeWithValidLengthSpecification invoiceMustHaveCodeWithValidLengthSpecification,
            IInvoiceMustHaveCustomerSpecification invoiceMustHaveCustomerSpecification,
            IInvoiceMustHaveItensSpecification invoiceMustHaveItensSpecification,
            IInvoiceMustHaveValidDateSpecification invoiceMustHaveValidDateSpecification
            ) : base(domainModelMustExistsSpecification, domainModelMustHaveCreationDateSpecification, domainModelMustHaveCreationUserSpecification, domainModelMustHaveIdSpecification, domainModelMustHaveModificationDateGreaterThanCreationDateSpecification, domainModelMustHaveModificationDateSpecification, domainModelMustHaveModificationUserSpecification, domainModelMustHaveTenantCodeSpecification, domainModelMustHaveTenantCodeWithValidLengthSpecification, domainModelMustNotExistsSpecification)
        {
            AddMustHaveTenantCodeSpecification();
            AddMustHaveTenantCodeWithValidLengthSpecification();

            AddSpecification(invoiceMustHaveCodeSpecification);
            AddSpecification(invoiceMustHaveCodeWithValidLengthSpecification);
            AddSpecification(invoiceMustHaveCustomerSpecification);
            AddSpecification(invoiceMustHaveItensSpecification);
            AddSpecification(invoiceMustHaveValidDateSpecification);
        }

        protected override Task ExecutePostValidateAsync(Invoice entity, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}

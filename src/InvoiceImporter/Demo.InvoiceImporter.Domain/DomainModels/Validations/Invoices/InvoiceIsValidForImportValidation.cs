using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.DomainModels.Base.Validations.Base;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Invoices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            IDomainModelMustNotExistsSpecification domainModelMustNotExistsSpecification) 
            : base(domainModelMustExistsSpecification, domainModelMustHaveCreationDateSpecification, domainModelMustHaveCreationUserSpecification, domainModelMustHaveIdSpecification, domainModelMustHaveModificationDateGreaterThanCreationDateSpecification, domainModelMustHaveModificationDateSpecification, domainModelMustHaveModificationUserSpecification, domainModelMustHaveTenantCodeSpecification, domainModelMustHaveTenantCodeWithValidLengthSpecification, domainModelMustNotExistsSpecification)
        {

        }
    }
}

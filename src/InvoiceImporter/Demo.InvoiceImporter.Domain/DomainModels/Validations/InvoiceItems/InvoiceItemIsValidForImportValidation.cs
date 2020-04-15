using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.DomainModels.Base.Validations.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.InvoiceItems.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.InvoiceItems.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.InvoiceItems
{
    public class InvoiceItemIsValidForImportValidation
        : DomainModelValidatorBase<InvoiceItem>,
        IInvoiceItemIsValidForImportValidation
    {
        public InvoiceItemIsValidForImportValidation(
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

            // InvoiceItens
            IInvoiceItemMustHaveInvoiceSpecification invoiceItemMustHaveInvoiceSpecification,
            IInvoiceItemMustHaveProductSpecification invoiceItemMustHaveProductSpecification,
            IInvoiceItemMustHaveQuatityWithValidLengthSpecification invoiceItemMustHaveQuatityWithValidLengthSpecification,
            IInvoiceItemMustHaveUnitPriceWithValidLengthSpecification invoiceItemMustHaveUnitPriceWithValidLengthSpecification
            ) : base(domainModelMustExistsSpecification, domainModelMustHaveCreationDateSpecification, domainModelMustHaveCreationUserSpecification, domainModelMustHaveIdSpecification, domainModelMustHaveModificationDateGreaterThanCreationDateSpecification, domainModelMustHaveModificationDateSpecification, domainModelMustHaveModificationUserSpecification, domainModelMustHaveTenantCodeSpecification, domainModelMustHaveTenantCodeWithValidLengthSpecification, domainModelMustNotExistsSpecification)
        {
            AddMustHaveTenantCodeSpecification();
            AddMustHaveTenantCodeWithValidLengthSpecification();

            AddSpecification(invoiceItemMustHaveInvoiceSpecification);
            AddSpecification(invoiceItemMustHaveProductSpecification);
            AddSpecification(invoiceItemMustHaveQuatityWithValidLengthSpecification);
            AddSpecification(invoiceItemMustHaveUnitPriceWithValidLengthSpecification);
        }

        protected override Task<bool> ExecutePostValidateAsync(InvoiceItem entity, ValidationResult validationResult)
        {
            throw new NotImplementedException();
        }
    }
}

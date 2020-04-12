using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.DomainModels.Base.Validations.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Products.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.Products
{
    public class ProductIsValidForImportValidation
        : DomainModelValidatorBase<Product>,
        IProductIsValidForImportValidation
    {
        public ProductIsValidForImportValidation(IDomainModelMustExistsSpecification domainModelMustExistsSpecification,
            IDomainModelMustHaveCreationDateSpecification domainModelMustHaveCreationDateSpecification,
            IDomainModelMustHaveCreationUserSpecification domainModelMustHaveCreationUserSpecification,
            IDomainModelMustHaveIdSpecification domainModelMustHaveIdSpecification,
            IDomainModelMustHaveModificationDateGreaterThanCreationDateSpecification domainModelMustHaveModificationDateGreaterThanCreationDateSpecification,
            IDomainModelMustHaveModificationDateSpecification domainModelMustHaveModificationDateSpecification,
            IDomainModelMustHaveModificationUserSpecification domainModelMustHaveModificationUserSpecification,
            IDomainModelMustHaveTenantCodeSpecification domainModelMustHaveTenantCodeSpecification,
            IDomainModelMustHaveTenantCodeWithValidLengthSpecification domainModelMustHaveTenantCodeWithValidLengthSpecification,
            IDomainModelMustNotExistsSpecification domainModelMustNotExistsSpecification,

            IProductMustHaveCodeSpecification productMustHaveCodeSpecification,
            IProductMustHaveCodeWithValidLengthSpecification productMustHaveCodeWithValidLengthSpecification,
            IProductMustHaveNameSpecification productMustHaveNameSpecification,
            IProductMustHaveNameWithValidLengthSpecification productMustHaveNameWithValidLengthSpecification
            ) : base(domainModelMustExistsSpecification, domainModelMustHaveCreationDateSpecification, domainModelMustHaveCreationUserSpecification, domainModelMustHaveIdSpecification, domainModelMustHaveModificationDateGreaterThanCreationDateSpecification, domainModelMustHaveModificationDateSpecification, domainModelMustHaveModificationUserSpecification, domainModelMustHaveTenantCodeSpecification, domainModelMustHaveTenantCodeWithValidLengthSpecification, domainModelMustNotExistsSpecification)
        {
            AddMustHaveTenantCodeSpecification();
            AddMustHaveTenantCodeWithValidLengthSpecification();

            AddSpecification(productMustHaveCodeSpecification);
            AddSpecification(productMustHaveCodeWithValidLengthSpecification);
            AddSpecification(productMustHaveNameSpecification);
            AddSpecification(productMustHaveNameWithValidLengthSpecification);
        }

        protected override Task ExecutePostValidateAsync(Product entity, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}

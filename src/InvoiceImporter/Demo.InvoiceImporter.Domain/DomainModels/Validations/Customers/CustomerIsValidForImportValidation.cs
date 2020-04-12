using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.DomainModels.Base.Validations.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers
{
    public class CustomerIsValidForImportValidation
        : DomainModelValidatorBase<Customer>,
        ICustomerIsValidForImportValidation
    {
        public CustomerIsValidForImportValidation(
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

            ICustomerGovernamentalDocumentNumberMustBeUniqueSpecification customerGovernamentalDocumentNumberMustBeUniqueSpecification,
            ICustomerMustHaveGovernamentalDocumentNumberSpecification customerMustHaveGovernamentalDocumentNumberSpecification,
            ICustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification customerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification,
            ICustomerMustHaveNameSpecification customerMustHaveNameSpecification,
            ICustomerMustHaveNameWithValidLengthSpecification customerMustHaveNameWithValidLengthSpecification,
            ICustomerMustHaveValidGovernamentalDocumentNumberSpecification customerMustHaveValidGovernamentalDocumentNumberSpecification
            ) : base(domainModelMustExistsSpecification, domainModelMustHaveCreationDateSpecification, domainModelMustHaveCreationUserSpecification, domainModelMustHaveIdSpecification, domainModelMustHaveModificationDateGreaterThanCreationDateSpecification, domainModelMustHaveModificationDateSpecification, domainModelMustHaveModificationUserSpecification, domainModelMustHaveTenantCodeSpecification, domainModelMustHaveTenantCodeWithValidLengthSpecification, domainModelMustNotExistsSpecification)
        {
            AddMustHaveTenantCodeSpecification();
            AddMustHaveTenantCodeWithValidLengthSpecification();

            AddSpecification(customerGovernamentalDocumentNumberMustBeUniqueSpecification);
            AddSpecification(customerMustHaveGovernamentalDocumentNumberSpecification);
            AddSpecification(customerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification);
            AddSpecification(customerMustHaveNameSpecification);
            AddSpecification(customerMustHaveNameWithValidLengthSpecification);
            AddSpecification(customerMustHaveValidGovernamentalDocumentNumberSpecification);
        }

        protected override Task ExecutePostValidateAsync(Customer entity, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}

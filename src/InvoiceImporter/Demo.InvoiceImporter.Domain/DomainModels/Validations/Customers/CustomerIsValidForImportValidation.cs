using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.DomainModels.Base.Validations.Base;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers
{
    public class CustomerIsValidForImportValidation
        : DomainModelValidationBase<Customer>,
        ICustomerIsValidForImportValidation
    {
        public CustomerIsValidForImportValidation(
            IDomainModelMustHaveIdSpecification domainModelMustHaveIdSpecification,
            IDomainModelMustExistsSpecification domainModelMustExistsSpecification,
            ICustomerGovernamentalDocumentNumberMustBeUniqueSpecification customerGovernamentalDocumentNumberMustBeUniqueSpecification,
            ICustomerMustHaveGovernamentalDocumentNumberSpecification customerMustHaveGovernamentalDocumentNumberSpecification,
            ICustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification customerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification,
            ICustomerMustHaveNameSpecification customerMustHaveNameSpecification,
            ICustomerMustHaveNameWithValidLengthSpecification customerMustHaveNameWithValidLengthSpecification)
            : base(domainModelMustHaveIdSpecification, domainModelMustExistsSpecification)
        {
            AddMustHaveIdSpecification();
            AddMustExistsSpecification();

            AddSpecification(customerGovernamentalDocumentNumberMustBeUniqueSpecification);
            AddSpecification(customerMustHaveGovernamentalDocumentNumberSpecification);
            AddSpecification(customerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification);
            AddSpecification(customerMustHaveNameSpecification);
            AddSpecification(customerMustHaveNameWithValidLengthSpecification);
        }
    }
}

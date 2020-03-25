using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers
{
    public class CustomerIsValidForImportValidation
        : Validator<Customer>,
        ICustomerIsValidForImportValidation
    {
        public CustomerIsValidForImportValidation(
            ICustomerMustHaveNameSpecification customerMustHaveNameSpecification,
            ICustomerMustHaveNameWithValidLengthSpecification customerMustHaveNameWithValidLengthSpecification)
        {
            AddSpecification(customerMustHaveNameSpecification);
            AddSpecification(customerMustHaveNameWithValidLengthSpecification);
        }
    }
}

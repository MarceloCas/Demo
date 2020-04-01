using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers
{
    public class CustomerIsValidForImportValidation
        : Validator<Customer>,
        ICustomerIsValidForImportValidation
    {
        public CustomerIsValidForImportValidation(
            ICustomerGovernamentalDocumentNumberMustBeUniqueSpecification customerGovernamentalDocumentNumberMustBeUniqueSpecification,
            ICustomerMustHaveGovernamentalDocumentNumberSpecification customerMustHaveGovernamentalDocumentNumberSpecification,
            ICustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification customerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification,
            ICustomerMustHaveNameSpecification customerMustHaveNameSpecification,
            ICustomerMustHaveNameWithValidLengthSpecification customerMustHaveNameWithValidLengthSpecification)
        {
            AddSpecification(customerGovernamentalDocumentNumberMustBeUniqueSpecification);
            AddSpecification(customerMustHaveGovernamentalDocumentNumberSpecification);
            AddSpecification(customerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification);
            AddSpecification(customerMustHaveNameSpecification);
            AddSpecification(customerMustHaveNameWithValidLengthSpecification);
        }
    }
}

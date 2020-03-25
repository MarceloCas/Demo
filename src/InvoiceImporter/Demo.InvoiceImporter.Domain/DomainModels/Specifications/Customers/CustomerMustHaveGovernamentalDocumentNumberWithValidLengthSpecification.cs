using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.ExtensionMethods;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers
{
    public class CustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification
        : SpecificationBase<Customer>,
        ICustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification
    {
        public CustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification(IGlobalizationConfig globalizationConfig) 
            : base(globalizationConfig)
        {
        }

        public async override Task<bool> IsSatisfiedBy(Customer entity)
        {
            return await Task.FromResult(entity?.GovernamentalDocumentNumber?.LengthIsBetween(1, 50) == true);
        }
    }
}

using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.ExtensionMethods;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers
{
    public class CustomerMustHaveNameWithValidLengthSpecification
        : SpecificationBase<Customer>,
        ICustomerMustHaveNameWithValidLengthSpecification
    {
        public CustomerMustHaveNameWithValidLengthSpecification(IGlobalizationConfig globalizationConfig) 
            : base(globalizationConfig)
        {
        }

        public async override Task<bool> IsSatisfiedBy(Customer entity)
        {
            return await Task.FromResult(entity?.Name?.LengthIsBetween(1, 150) == true);
        }
    }
}

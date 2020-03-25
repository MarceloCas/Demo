using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
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

        public override async Task<bool> IsSatisfiedBy(Customer entity)
        {
            var length = (entity?.Name?.Length ?? 0);

            return await Task.FromResult(length > 0 && length <= 150);
        }
    }
}

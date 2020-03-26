using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers
{
    public class CustomerMustHaveNameSpecification
        : SpecificationBase<Customer>,
        ICustomerMustHaveNameSpecification
    {
        public CustomerMustHaveNameSpecification(IGlobalizationConfig globalizationConfig) 
            : base(globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedBy(Customer entity)
        {
            return await Task.FromResult(!string.IsNullOrEmpty(entity?.Name));
        }
    }
}

using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers
{
    public class CustomerMustHaveGovernamentalDocumentNumberSpecification
        : SpecificationBase<Customer>,
        ICustomerMustHaveGovernamentalDocumentNumberSpecification
    {
        public CustomerMustHaveGovernamentalDocumentNumberSpecification(IGlobalizationConfig globalizationConfig) 
            : base(globalizationConfig)
        {
        }

        public async override Task<bool> IsSatisfiedBy(Customer entity)
        {
            return await Task.FromResult(!string.IsNullOrEmpty(entity?.GovernamentalDocumentNumber));
        }
    }
}

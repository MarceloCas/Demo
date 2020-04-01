using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers
{
    public class CustomerMustExistsSpecification
        : SpecificationBase<Customer>,
        ICustomerMustExistsSpecification
    {
        public CustomerMustExistsSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override Task<bool> IsSatisfiedByAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces
{
    public interface ICustomerMustNotExistsSpecification
        : ISpecification<Customer>
    {

    }
}

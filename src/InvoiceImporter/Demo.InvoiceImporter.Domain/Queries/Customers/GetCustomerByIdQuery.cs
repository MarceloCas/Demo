using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.InvoiceImporter.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.Queries.Customers
{
    public class GetCustomerByIdQuery
        : Query<Customer>
    {
    }
}

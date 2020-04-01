using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces
{
    public interface IGetCustomerByIdQueryFactory
        : IFactory<GetCustomerByIdQuery>
    {
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer;

namespace Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces
{
    public interface IBrazilianCustomerFactory
        : IFactory<BrazilianCustomer>
    {
    }
}

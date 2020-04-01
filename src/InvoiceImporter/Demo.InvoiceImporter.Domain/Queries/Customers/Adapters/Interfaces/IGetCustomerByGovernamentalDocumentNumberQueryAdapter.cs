using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces
{
    public interface IGetCustomerByGovernamentalDocumentNumberQueryAdapter
        : IAdapter<GetCustomerByGovernamentalDocumentNumberQuery, Customer>
    {

    }
}

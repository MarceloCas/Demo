using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.Queries.Products.Adapters.Interfaces
{
    public interface IGetProductByCodeQueryAdapter
        : IAdapter<GetProductByCodeQuery, Product>
    {
    }
}

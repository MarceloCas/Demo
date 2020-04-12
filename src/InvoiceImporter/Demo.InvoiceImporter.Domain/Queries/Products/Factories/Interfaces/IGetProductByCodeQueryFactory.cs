using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.Queries.Products.Factories.Interfaces
{
    public interface IGetProductByCodeQueryFactory
        : IFactory<GetProductByCodeQuery>
    {
    }
}

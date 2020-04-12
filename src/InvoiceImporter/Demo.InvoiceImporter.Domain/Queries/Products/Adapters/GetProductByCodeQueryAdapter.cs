using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Queries.Products.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Queries.Products.Adapters
{
    public class GetProductByCodeQueryAdapter
        : AdapterBase,
        IGetProductByCodeQueryAdapter
    {
        public async Task<GetProductByCodeQuery> AdapteeAsync(Product source, GetProductByCodeQuery to)
        {
            to.SetCode(source.Code);

            return await Task.FromResult(to);
        }
    }
}

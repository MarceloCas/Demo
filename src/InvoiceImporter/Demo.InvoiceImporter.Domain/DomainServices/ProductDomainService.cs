﻿using Demo.Core.Domain.Repositories.Base;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class ProductDomainService
        : DomainServiceBase<Product>,
        IProductDomainService
    {
        public ProductDomainService(
            IProductRepository repository,
            IProductFactory productFactory) 
            : base(repository, productFactory)
        {
        }

        public async Task<Product> ImportProductAsync(string tenantCode, string creationUser, Product productToImport)
        {
            // Validation

            var importedProduct = Factory.Create().ImportProduct(
                tenantCode,
                productToImport.Name,
                productToImport.Code,
                creationUser);

            importedProduct = await Bus.AddAsync(importedProduct);

            return importedProduct;
        }
    }
}

﻿using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.ExtensionMethods;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Products
{
    public class ProductMustHaveNameWithValidLengthSpecification
        : SpecificationBase<Product>,
        IProductMustHaveNameWithValidLengthSpecification
    {
        public ProductMustHaveNameWithValidLengthSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(Product entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
                return await Task.FromResult(true);

            return await Task.FromResult(entity?.Name?.LengthIsBetween(1, 250) == true);
        }
    }
}

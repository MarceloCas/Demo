﻿using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.InvoiceItems.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.InvoiceItems
{
    public class InvoiceItemMustHaveProductSpecification
        : SpecificationBase<InvoiceItem>,
        IInvoiceItemMustHaveProductSpecification
    {
        public InvoiceItemMustHaveProductSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(InvoiceItem entity)
        {
            return await Task.FromResult((entity?.Product?.Id ?? Guid.Empty) != Guid.Empty);
        }
    }
}

﻿using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromXMLFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromXMLFiles
{
    public class InvoiceItemMustHaveQuantitySpecification
        : SpecificationBase<InvoiceItemViewModel>,
        IInvoiceItemMustHaveQuantitySpecification
    {
        public InvoiceItemMustHaveQuantitySpecification(
            IBus bus,
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(InvoiceItemViewModel entity)
        {
            return await Task.FromResult((entity?.Quantity ?? -1) >= 0);
        }
    }
}

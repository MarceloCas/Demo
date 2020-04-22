using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromCSVFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromCSVFiles
{
    public class InvoiceCSVLineMustHaveProductCodeSpecification
        : SpecificationBase<FileLineViewModel>,
        IInvoiceCSVLineMustHaveProductCodeSpecification
    {
        public InvoiceCSVLineMustHaveProductCodeSpecification(
            IBus bus,
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(FileLineViewModel entity)
        {
            return await Task.FromResult(!string.IsNullOrWhiteSpace(entity?.ProductCode));
        }
    }
}

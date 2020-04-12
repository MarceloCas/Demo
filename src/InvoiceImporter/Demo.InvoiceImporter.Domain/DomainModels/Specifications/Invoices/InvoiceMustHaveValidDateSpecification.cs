using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.ExtensionMethods;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices
{
    public class InvoiceMustHaveValidDateSpecification
        : SpecificationBase<Invoice>,
        IInvoiceMustHaveValidDateSpecification
    {
        public InvoiceMustHaveValidDateSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(Invoice entity)
        {
            return await Task.FromResult(entity?.Date.IsLessThan(DateTime.UtcNow, acceptMinValue: false) == true);
        }
    }
}

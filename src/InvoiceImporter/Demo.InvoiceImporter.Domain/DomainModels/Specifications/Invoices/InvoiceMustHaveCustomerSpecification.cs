using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices
{
    public class InvoiceMustHaveCustomerSpecification
        : SpecificationBase<Invoice>,
        IInvoiceMustHaveCustomerSpecification
    {
        public InvoiceMustHaveCustomerSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(Invoice entity)
        {
            return await Task.FromResult((entity?.Customer?.Id ?? Guid.Empty) != Guid.Empty);
        }

    }
}

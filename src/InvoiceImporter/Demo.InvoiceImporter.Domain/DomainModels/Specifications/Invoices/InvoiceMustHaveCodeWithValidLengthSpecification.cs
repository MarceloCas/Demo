using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.ExtensionMethods;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices
{
    public class InvoiceMustHaveCodeWithValidLengthSpecification
        : SpecificationBase<Invoice>,
        IInvoiceMustHaveCodeWithValidLengthSpecification
    {
        public InvoiceMustHaveCodeWithValidLengthSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(Invoice entity)
        {
            if (string.IsNullOrWhiteSpace(entity?.Code))
                return await Task.FromResult(true);

            return await Task.FromResult((entity?.Code ?? string.Empty).LengthIsBetween(1, 150));
        }
    }
}

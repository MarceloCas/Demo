using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.InvoiceItems.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.InvoiceItems
{
    public class InvoiceItemMustHaveQuatityWithValidLengthSpecification
        : SpecificationBase<InvoiceItem>,
        IInvoiceItemMustHaveQuatityWithValidLengthSpecification
    {
        public InvoiceItemMustHaveQuatityWithValidLengthSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(InvoiceItem entity)
        {
            return await Task.FromResult((entity?.Quantity ?? 0) > 0);
        }
    }
}

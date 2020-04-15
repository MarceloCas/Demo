using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices
{
    public class InvoiceMustHaveItensSpecification
        : SpecificationBase<Invoice>,
        IInvoiceMustHaveItensSpecification
    {
        public InvoiceMustHaveItensSpecification(
            IBus bus, 
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(Invoice entity)
        {
            return await Task.FromResult(entity?.InvoiceItemCollection?.Any() == true);
        }
    }
}

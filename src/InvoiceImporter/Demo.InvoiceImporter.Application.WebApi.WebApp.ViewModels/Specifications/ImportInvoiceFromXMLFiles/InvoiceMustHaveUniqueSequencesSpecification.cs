using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromXMLFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromXMLFiles
{
    public class InvoiceMustHaveUniqueSequencesSpecification
        : SpecificationBase<InvoiceViewModel>,
        IInvoiceMustHaveUniqueSequencesSpecification
    {
        public InvoiceMustHaveUniqueSequencesSpecification(
            IBus bus,
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(InvoiceViewModel entity)
        {
            var isSatisfied = true;

            var sequenceCollection = entity?.InvoiceItemCollection?.Select(q => q.Sequence).Distinct();
            foreach (var sequence in sequenceCollection)
                if (entity?.InvoiceItemCollection?.Where(q =>
                    q.Sequence == sequence)
                    .Count() > 1)
                {
                    isSatisfied = false;
                    break;
                }

            return await Task.FromResult(isSatisfied);
        }
    }
}

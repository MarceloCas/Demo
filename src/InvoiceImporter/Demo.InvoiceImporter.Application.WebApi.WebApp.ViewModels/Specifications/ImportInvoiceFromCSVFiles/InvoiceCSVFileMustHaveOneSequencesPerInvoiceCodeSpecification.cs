using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromCSVFiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromCSVFiles
{
    public class InvoiceCSVFileMustHaveOneSequencesPerInvoiceCodeSpecification
        : SpecificationBase<ImportInvoiceFromCSVFileViewModel>,
        IInvoiceCSVFileMustHaveOneSequencesPerInvoiceCodeSpecification
    {
        public InvoiceCSVFileMustHaveOneSequencesPerInvoiceCodeSpecification(
            IBus bus,
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(ImportInvoiceFromCSVFileViewModel entity)
        {
            var isSatisfied = true;

            if (entity?.FileLineCollection == null)
            {
                isSatisfied = false;
            }
            else
            {
                var invoiceCodeCollection = entity.FileLineCollection.Select(q => q.InvoiceCode).Distinct();
                foreach (var invoiceCode in invoiceCodeCollection)
                {
                    var sequenceCollection = entity.FileLineCollection
                        .Where(q => q.InvoiceCode == invoiceCode)
                        .Select(q => q.InvoiceItemSequence)
                        .Distinct();

                    foreach (var sequence in sequenceCollection)
                    {
                        if (entity.FileLineCollection
                            .Where(q => 
                                q.InvoiceCode == invoiceCode
                                && q.InvoiceItemSequence == sequence
                            ).Count() > 1
                            )
                        {
                            isSatisfied = false;
                            break;
                        }
                    }
                }
            }

            return await Task.FromResult(isSatisfied);
        }
    }
}

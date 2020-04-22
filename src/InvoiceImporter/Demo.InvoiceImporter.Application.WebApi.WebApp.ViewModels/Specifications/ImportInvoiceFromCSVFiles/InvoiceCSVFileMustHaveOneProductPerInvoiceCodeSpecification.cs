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
    public class InvoiceCSVFileMustHaveOneProductPerInvoiceCodeSpecification
        : SpecificationBase<ImportInvoiceFromCSVFileViewModel>,
        IInvoiceCSVFileMustHaveOneProductPerInvoiceCodeSpecification
    {
        public InvoiceCSVFileMustHaveOneProductPerInvoiceCodeSpecification(
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
                var invoiceCodeCollection = entity.FileLineCollection.Select(q => q.InvoiceCode);
                foreach (var invoiceCode in invoiceCodeCollection)
                {
                    if (entity.FileLineCollection
                        .Where(q => q.InvoiceCode == invoiceCode)
                        .Select(q => q.ProductCode)
                        .Distinct()
                        .Count() > 1
                        )
                    {
                        isSatisfied = false;
                        break;
                    }
                }
            }

            return await Task.FromResult(isSatisfied);
        }
    }
}

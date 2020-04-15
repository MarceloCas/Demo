using Demo.Core.Domain.ValueObjects;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter;
using Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands
{
    public class ImportInvoiceCommandAdapter
        : AdapterBase,
        IImportInvoiceCommandAdapter
    {
        public TenantInfoValueObject TenantInfoValueObject { get; private set; }

        public ImportInvoiceCommandAdapter(ITenantInfoValueObjectFactory tenantInfoValueObjectFactory)
        {
            TenantInfoValueObject = tenantInfoValueObjectFactory.CreateAsync().Result;
        }

        public async Task<ImportInvoiceCommand> AdapteeAsync(InvoiceViewModel source, ImportInvoiceCommand to)
        {
            to.Code = source.Code;
            to.Customer = new Customer
            {
                GovernamentalDocumentNumber = to?.Customer?.GovernamentalDocumentNumber,
                Name = to?.Customer?.Name
            };
            to.Date = source?.Date ?? DateTime.MinValue;
            to.RequestUser = TenantInfoValueObject.TenantCode;

            to.InvoiceItemCollection = new List<InvoiceItem>();

            if (source?.InvoiceItemCollection != null)
            {
                foreach (var invoiceItem in source.InvoiceItemCollection)
                {
                    to.InvoiceItemCollection.Add(new InvoiceItem { 
                        Product = new Product { Code = invoiceItem?.Product?.Code, Name = invoiceItem?.Product?.Name },
                        Sequence = invoiceItem.Sequence,
                        Quantity = invoiceItem.Quantity,
                        UnitPrice = invoiceItem.UnitPrice
                    });
                }
            }

            return await Task.FromResult(to);
        }
    }
}

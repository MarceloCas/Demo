using Demo.Core.Domain.ValueObjects;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter;
using Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands
{
    public class ImportInvoiceCommandAdapter
        : AdapterBase,
        IImportInvoiceCommandAdapter
    {
        // Attributes
        private readonly TenantInfoValueObject _tenantInfoValueObject;

        // Constructors
        public ImportInvoiceCommandAdapter(ITenantInfoValueObjectFactory tenantInfoValueObjectFactory)
        {
            _tenantInfoValueObject = tenantInfoValueObjectFactory.CreateAsync().Result;
        }

        // Public methods
        public async Task<List<ImportInvoiceCommand>> AdapteeAsync(ImportInvoiceFromXMLFileViewModel source, List<ImportInvoiceCommand> to)
        {
            foreach (var invoiceViewModel in source.InvoiceViewModelCollection)
            {
                var importInvoiceCommand = new ImportInvoiceCommand
                {
                    Code = invoiceViewModel.Code
                };
                importInvoiceCommand.Customer = new Customer
                {
                    GovernamentalDocumentNumber = importInvoiceCommand.Customer.GovernamentalDocumentNumber,
                    Name = importInvoiceCommand.Customer.Name
                };
                importInvoiceCommand.Date = invoiceViewModel.Date;
                importInvoiceCommand.RequestUser = _tenantInfoValueObject.TenantCode;

                importInvoiceCommand.InvoiceItemCollection = new List<InvoiceItem>();

                foreach (var invoiceItem in invoiceViewModel.InvoiceItemCollection)
                {
                    importInvoiceCommand.InvoiceItemCollection.Add(new InvoiceItem
                    {
                        Product = new Product { Code = invoiceItem.Product.Code, Name = invoiceItem.Product.Name },
                        Sequence = invoiceItem.Sequence,
                        Quantity = invoiceItem.Quantity,
                        UnitPrice = invoiceItem.UnitPrice
                    });
                }

                to.Add(importInvoiceCommand);
            }

            return await Task.FromResult(to);
        }
        public async Task<List<ImportInvoiceCommand>> AdapteeAsync(ImportInvoiceFromCSVFileViewModel source, List<ImportInvoiceCommand> to)
        {
            var invoiceCodeCollection = source.FileLineCollection?.Select(q => q.InvoiceCode).Where(q => !string.IsNullOrEmpty(q)).Distinct();

            foreach (var invoiceCode in invoiceCodeCollection)
            {
                var invoiceLinesCollection = source.FileLineCollection.Where(q => q.InvoiceCode == invoiceCode);
                var firstLine = invoiceLinesCollection.FirstOrDefault();

                var importInvoiceCommand = new ImportInvoiceCommand
                {
                    Code = invoiceCode,
                    Customer = new Customer
                    {
                        GovernamentalDocumentNumber = firstLine.CustomerGovernamentalDocumentNumber,
                        Name = firstLine.CustomerName
                    },
                    Date = DateTime.Parse(firstLine.InvoiceDate),
                    RequestUser = _tenantInfoValueObject.TenantCode,

                    InvoiceItemCollection = new List<InvoiceItem>()
                };

                foreach (var invoiceLine in invoiceLinesCollection)
                {
                    importInvoiceCommand.InvoiceItemCollection.Add(new InvoiceItem
                    {
                        Product = new Product { Code = invoiceLine.ProductCode, Name = invoiceLine.ProductName },
                        Sequence = int.Parse(invoiceLine.InvoiceItemSequence),
                        Quantity = double.Parse(invoiceLine.InvoiceItemQuantity),
                        UnitPrice = double.Parse(invoiceLine.InvoiceItemUnitPrice)
                    });
                }

                to.Add(importInvoiceCommand);
            }

            return await Task.FromResult(to);
        }
    }
}

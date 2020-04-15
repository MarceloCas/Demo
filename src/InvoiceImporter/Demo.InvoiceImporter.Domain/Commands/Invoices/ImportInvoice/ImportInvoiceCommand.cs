using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;

namespace Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice
{
    public class ImportInvoiceCommand
        : Command
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }

        public Customer Customer { get; set; }
        public List<InvoiceItem> InvoiceItemCollection { get; set; }

        public ImportInvoiceCommand()
        {
            Customer = new Customer();
            InvoiceItemCollection = new List<InvoiceItem>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile
{
    public class FileLineViewModel
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerGovernamentalDocumentNumber { get; set; }
        public string InvoiceCode { get; set; }
        public string InvoiceDate { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string InvoiceItemSequence { get; set; }
        public string InvoiceItemQuantity { get; set; }
        public string InvoiceItemUnitPrice { get; set; }
    }
}

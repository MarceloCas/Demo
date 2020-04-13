using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile
{
    public class InvoiceViewModel
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }

        public CustomerViewModel Customer { get; set; }
        public List<InvoiceItemViewModel> InvoiceItemCollection { get; set; }

        public InvoiceViewModel()
        {
            Customer = new CustomerViewModel();
            InvoiceItemCollection = new List<InvoiceItemViewModel>();
        }
    }
}

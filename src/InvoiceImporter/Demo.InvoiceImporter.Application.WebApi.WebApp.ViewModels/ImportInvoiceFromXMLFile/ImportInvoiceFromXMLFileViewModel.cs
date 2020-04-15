using System.Collections.Generic;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile
{
    public class ImportInvoiceFromXMLFileViewModel
    {
        public List<InvoiceViewModel> InvoiceViewModelCollection { get; set; }

        public ImportInvoiceFromXMLFileViewModel()
        {
            InvoiceViewModelCollection = new List<InvoiceViewModel>();
        }
    }
}

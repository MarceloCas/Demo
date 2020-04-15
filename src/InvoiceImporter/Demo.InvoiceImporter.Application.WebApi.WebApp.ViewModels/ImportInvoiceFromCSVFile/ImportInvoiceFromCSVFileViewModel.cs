using System.Collections.Generic;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile
{
    public class ImportInvoiceFromCSVFileViewModel
    {
        public List<FileLineViewModel> FileLineCollection { get; set; }

        public ImportInvoiceFromCSVFileViewModel()
        {
            FileLineCollection = new List<FileLineViewModel>();
        }
    }
}

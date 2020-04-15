namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile
{
    public class InvoiceItemViewModel
    {
        public int Sequence { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public ProductViewModel Product { get; set; }

        public InvoiceItemViewModel()
        {
            Product = new ProductViewModel();
        }
    }
}

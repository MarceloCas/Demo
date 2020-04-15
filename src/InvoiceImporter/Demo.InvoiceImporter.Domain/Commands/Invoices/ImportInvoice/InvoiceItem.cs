namespace Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice
{
    public class InvoiceItem
    {
        public int Sequence { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Product Product { get; set; }

        public InvoiceItem()
        {
            Product = new Product();
        }
    }
}

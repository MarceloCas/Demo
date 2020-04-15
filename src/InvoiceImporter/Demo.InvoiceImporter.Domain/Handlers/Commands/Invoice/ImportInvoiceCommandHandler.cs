using Demo.Core.Domain.Handlers.Commands;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice
{
    public class ImportInvoiceCommandHandler
        : CommandHandlerBase<ImportInvoiceCommand>,
        IImportInvoiceCommandHandler
    {
        // Attributes
        private readonly ICustomerDomainService _customerDomainService;
        private readonly IProductDomainService _productDomainService;
        private readonly IInvoiceDomainService _invoiceDomainService;

        // Constructors
        public ImportInvoiceCommandHandler(
            ICustomerDomainService customerDomainService,
            IProductDomainService productDomainService,
            IInvoiceDomainService invoiceDomainService)
        {
            _customerDomainService = customerDomainService;
            _productDomainService = productDomainService;
            _invoiceDomainService = invoiceDomainService;
        }

        // Protected Methods
        protected override CommandHandler<ImportInvoiceCommand> GetCommandHandler()
        {
            return async command =>
            {


                return await Task.FromResult(true);
            };
        }
    }
}

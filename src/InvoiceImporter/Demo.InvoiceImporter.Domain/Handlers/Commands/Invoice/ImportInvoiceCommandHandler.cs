using Demo.Core.Domain.Handlers.Commands;
using Demo.InvoiceImporter.Domain.Commands.Invoices;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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

        // Public Methods
        public override async Task<bool> HandleAsync(ImportInvoiceCommand command)
        {
            return await Task.FromResult(true);
        }
    }
}

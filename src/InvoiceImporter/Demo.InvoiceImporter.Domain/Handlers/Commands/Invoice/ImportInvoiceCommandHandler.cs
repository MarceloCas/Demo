using Demo.Core.Domain.Handlers.Commands;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using System.Collections.Generic;

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

        private readonly IInvoiceFactory _invoiceFactory;

        // Constructors
        public ImportInvoiceCommandHandler(
            IInMemoryDefaultDomainNotificationHandler inMemoryDefaultDomainNotificationHandler,
            ITenantInfoValueObjectFactory tenantInfoValueObjectFactory,
            ICustomerDomainService customerDomainService,
            IProductDomainService productDomainService,
            IInvoiceDomainService invoiceDomainService,
            IInvoiceFactory invoiceFactory
            ) : base(tenantInfoValueObjectFactory, inMemoryDefaultDomainNotificationHandler)
        {
            _customerDomainService = customerDomainService;
            _productDomainService = productDomainService;
            _invoiceDomainService = invoiceDomainService;

            _invoiceFactory = invoiceFactory;
        }

        // Protected Methods
        protected override CommandHandler<ImportInvoiceCommand> GetCommandHandler()
        {
            return async command =>
            {
                var invoiceToImport = await _invoiceFactory.CreateAsync(command);
                var importedProductsCollection = new List<DomainModels.Product>();

                var productCollection = invoiceToImport.InvoiceItemCollection.Select(invoiceItem => invoiceItem.Product);

                // Import customer
                invoiceToImport.SetCustomer(await _customerDomainService.ImportCustomerAsync(
                    TenantInfoValueObject.TenantCode,
                    command.RequestUser,
                    invoiceToImport.Customer));

                // Import all products
                foreach (var product in productCollection)
                {
                    importedProductsCollection.Add(await _productDomainService.ImportProductAsync(
                        TenantInfoValueObject.TenantCode,
                        command.RequestUser,
                        product)
                    );
                }

                // Update invoice items products
                foreach (var invoiceItem in invoiceToImport.InvoiceItemCollection)
                    invoiceItem.SetProduct(importedProductsCollection.FirstOrDefault(q =>
                        q.Code == invoiceItem.Product.Code)
                    );

                // Import invoice
                await _invoiceDomainService.ImportInvoiceAsync(
                    TenantInfoValueObject.TenantCode,
                    command.RequestUser,
                    invoiceToImport);

                // Check errors
                var sucess = !InMemoryDefaultDomainNotificationHandler.DomainNotificationsCollection.Any();

                return await Task.FromResult(sucess);
            };
        }
    }
}

﻿using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices.Base;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Events.Invoices.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices
{
    public class InvoiceDomainService
        : DomainServiceBase<Invoice>,
        IInvoiceDomainService
    {
        private readonly IInvoiceWasImportedEventFactory _invoiceWasImportedEventFactory;

        public InvoiceDomainService(
            IBus bus,
            IInvoiceFactory invoiceFactory,
            IInvoiceWasImportedEventFactory invoiceWasImportedEventFactory
            ) 
            : base(bus, invoiceFactory)
        {
            _invoiceWasImportedEventFactory = invoiceWasImportedEventFactory;
        }

        public async Task<Invoice> ImportInvoiceAsync(string tenantCode, string creationUser, Invoice invoiceToImport)
        {
            // Validation

            // Process
            var importedInvoice = (await Factory.CreateAsync()).ImportInvoice(
                tenantCode,
                invoiceToImport.Code,
                invoiceToImport.Date,
                invoiceToImport.Customer,
                invoiceToImport.InvoiceItemCollection,
                creationUser);

            // Notify
            _ = await Bus.SendEventAsync(await _invoiceWasImportedEventFactory.CreateAsync(importedInvoice));

            return importedInvoice;
        }
    }
}

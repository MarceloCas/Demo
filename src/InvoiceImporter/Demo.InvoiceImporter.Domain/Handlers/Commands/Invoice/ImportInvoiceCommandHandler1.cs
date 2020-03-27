using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;
using Demo.InvoiceImporter.Domain.Commands.Invoices;
using Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice
{
    public class ImportInvoiceCommandHandler1
        : IImportInvoiceCommandHandler
    {
        private readonly IBus _bus;

        public ImportInvoiceCommandHandler1(IBus bus)
        {
            _bus = bus;
        }

        public async Task<bool> HandleAsync(ImportInvoiceCommand command)
        {
            await _bus.SendDomainNotification(new DomainNotification()
            {
                Code = "ERROR_1",
                DefaultDescription = "Erro do handler 1",
                Type = DomainNotificationTypeEnum.Error
            });

            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Events.Invoices.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Events.Invoices
{
    public class InvoiceWasImportedEvent
        : Event
    {
        public Invoice Invoice { get; protected set; }

        protected InvoiceWasImportedEvent() { }

        #region Factories
        public class InvoiceWasImportedEventFactory
            : FactoryBase<InvoiceWasImportedEvent>,
            IInvoiceWasImportedEventFactory
        {
            public InvoiceWasImportedEventFactory(
                IGlobalizationConfig globalizationConfig
                ) : base(globalizationConfig)
            {
            }

            public override async Task<InvoiceWasImportedEvent> CreateAsync()
            {
                return await Task.FromResult(new InvoiceWasImportedEvent());
            }

            public async Task<InvoiceWasImportedEvent> CreateAsync(Invoice parameter)
            {
                var invoiceWasImportedEvent = await CreateAsync();

                invoiceWasImportedEvent.Invoice = parameter;

                return invoiceWasImportedEvent;
            }
        }
        #endregion
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Events.Customers.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Events.Customers
{
    public class CustomerWasUpdatedEvent
        : Event
    {
        public Customer Customer { get; protected set; }

        protected CustomerWasUpdatedEvent() { }

        #region Factories
        public class CustomerWasUpdatedEventFactory
            : FactoryBase<CustomerWasUpdatedEvent>,
            ICustomerWasUpdatedEventFactory
        {
            public CustomerWasUpdatedEventFactory(
                IGlobalizationConfig globalizationConfig
                ) : base(globalizationConfig)
            {
            }

            public override async Task<CustomerWasUpdatedEvent> CreateAsync()
            {
                return await Task.FromResult(new CustomerWasUpdatedEvent());
            }

            public async Task<CustomerWasUpdatedEvent> CreateAsync(Customer parameter)
            {
                var customerWasImportedEvent = await CreateAsync();

                customerWasImportedEvent.Customer = parameter;

                return customerWasImportedEvent;
            }
        }
        #endregion
    }
}

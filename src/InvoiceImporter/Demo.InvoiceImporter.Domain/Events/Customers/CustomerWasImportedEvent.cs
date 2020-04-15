using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Events.Customers.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.Events.Customers
{
    public class CustomerWasImportedEvent
        : Event
    {
        public Customer Customer { get; protected set; }

        protected CustomerWasImportedEvent() { }

        #region Factories
        public class CustomerWasImportedEventFactory
            : FactoryBase<CustomerWasImportedEvent>,
            ICustomerWasImportedEventFactory
        {
            public CustomerWasImportedEventFactory(
                IGlobalizationConfig globalizationConfig
                ) : base(globalizationConfig)
            {
            }

            public override async Task<CustomerWasImportedEvent> CreateAsync()
            {
                return await Task.FromResult(new CustomerWasImportedEvent());
            }

            public async Task<CustomerWasImportedEvent> CreateAsync(Customer parameter)
            {
                var customerWasImportedEvent = await CreateAsync();

                customerWasImportedEvent.Customer = parameter;

                return customerWasImportedEvent;
            }
        }
        #endregion
    }
}

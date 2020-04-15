using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;

namespace Demo.InvoiceImporter.Domain.Events.Customers.Factories.Interfaces
{
    public interface ICustomerWasUpdatedEventFactory
        : IFactoryWithParameters<CustomerWasUpdatedEvent, Customer>
    {
    }
}

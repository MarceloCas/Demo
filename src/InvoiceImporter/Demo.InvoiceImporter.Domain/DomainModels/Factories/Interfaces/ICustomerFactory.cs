using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice;

namespace Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces
{
    public interface ICustomerFactory
        : IFactory<Customer>,
        IFactoryWithParameters<Customer, ImportInvoiceCommand>
    {
    }
}

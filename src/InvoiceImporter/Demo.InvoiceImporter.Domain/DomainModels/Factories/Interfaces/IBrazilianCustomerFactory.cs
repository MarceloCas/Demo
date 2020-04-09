using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer;

namespace Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces
{
    public interface IBrazilianCustomerFactory
        : IFactory<BrazilianCustomer>
    {
    }
}

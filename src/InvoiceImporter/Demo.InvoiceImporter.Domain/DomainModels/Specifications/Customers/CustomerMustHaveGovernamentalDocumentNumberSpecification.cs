using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using System.Threading.Tasks;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers
{
    public class CustomerMustHaveGovernamentalDocumentNumberSpecification
        : SpecificationBase<Customer>,
        ICustomerMustHaveGovernamentalDocumentNumberSpecification
    {
        public CustomerMustHaveGovernamentalDocumentNumberSpecification(
            IBus bus,
            IGlobalizationConfig globalizationConfig) 
            : base(bus, globalizationConfig)
        {
        }

        public async override Task<bool> IsSatisfiedByAsync(Customer entity)
        {
            return await Task.FromResult(!string.IsNullOrEmpty(entity?.GovernamentalDocumentNumber));
        }
    }
}

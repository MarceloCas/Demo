using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using System.Threading.Tasks;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers
{
    public class CustomerMustHaveValidGovernamentalDocumentNumberSpecification
        : SpecificationBase<Customer>,
        ICustomerMustHaveValidGovernamentalDocumentNumberSpecification
    {
        public CustomerMustHaveValidGovernamentalDocumentNumberSpecification(
            IBus bus,
            IGlobalizationConfig globalizationConfig) 
            : base(bus, globalizationConfig)
        {
        }

        public async override Task<bool> IsSatisfiedByAsync(Customer entity)
        {
            if (string.IsNullOrWhiteSpace(entity?.GovernamentalDocumentNumber))
                return false;

            var isValid = GlobalizationConfig.Localization switch
            {
                LocalizationsEnum.Default => await ValidateGovernamentalDocumentNumberAsync(entity),
                LocalizationsEnum.Brazil => await ValidateCNPJAsync(entity),
                _ => false,
            };

            return isValid;
        }

        private async Task<bool> ValidateGovernamentalDocumentNumberAsync(Customer entity)
        {
            return await Task.FromResult(true);
        }
        private async Task<bool> ValidateCNPJAsync(Customer entity)
        {
            return await Task.FromResult(true);
        }
    }
}

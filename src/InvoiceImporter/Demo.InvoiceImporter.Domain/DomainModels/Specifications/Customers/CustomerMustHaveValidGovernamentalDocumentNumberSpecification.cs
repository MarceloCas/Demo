using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers
{
    public class CustomerMustHaveValidGovernamentalDocumentNumberSpecification
        : SpecificationBase<Customer>,
        ICustomerMustHaveValidGovernamentalDocumentNumberSpecification
    {
        public CustomerMustHaveValidGovernamentalDocumentNumberSpecification(IGlobalizationConfig globalizationConfig) 
            : base(globalizationConfig)
        {
        }

        public async override Task<bool> IsSatisfiedBy(Customer entity)
        {
            if (string.IsNullOrWhiteSpace(entity?.GovernamentalDocumentNumber))
                return false;

            var isValid = GlobalizationConfig.Localization switch
            {
                LocalizationsEnum.Default => await ValidateGovernamentalDocumentNumber(entity),
                LocalizationsEnum.Brazil => await ValidateCNPJ(entity),
                _ => false,
            };

            return isValid;
        }

        private async Task<bool> ValidateGovernamentalDocumentNumber(Customer entity)
        {
            return await Task.FromResult(true);
        }
        private async Task<bool> ValidateCNPJ(Customer entity)
        {
            return await Task.FromResult(true);
        }
    }
}

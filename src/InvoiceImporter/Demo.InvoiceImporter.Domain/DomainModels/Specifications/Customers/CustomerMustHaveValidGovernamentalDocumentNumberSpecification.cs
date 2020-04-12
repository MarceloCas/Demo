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
			/*
			 * http://www.macoratti.net/11/09/c_val1.htm
			 */

			var cnpj = entity?.GovernamentalDocumentNumber;

			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;

			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

			if (cnpj.Length != 14)
				return false;

			tempCnpj = cnpj.Substring(0, 12);

			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito = resto.ToString();

			tempCnpj += digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito += resto.ToString();

			return await Task.FromResult(cnpj.EndsWith(digito));
        }
	}
}

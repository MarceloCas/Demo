using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.IoC.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Demo.InvoiceImporter.Infra.IoC.WebApi.WebApp
{
    public class DefaultBootstrapper
        : IoC.DefaultBootstrapper
    {
        public DefaultBootstrapper(
            IServiceCollection services,
            string tenantCode,
            string cultureName,
            LocalizationsEnum localization
            ) : base(services, tenantCode, cultureName, localization)
        {

        }

        public override TypeRegistration[] GetTypeRegistrationCollection()
        {
            var typeRegistrationCollection = base.GetTypeRegistrationCollection().ToList();

            typeRegistrationCollection.AddRange(new Application.WebApi.WebApp.IoC.DefaultBootstrapper(Services, TenantCode, CultureName, Localization).TypeRegistrationCollection);

            return typeRegistrationCollection.ToArray();
        }
    }
}

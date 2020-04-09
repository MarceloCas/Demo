using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.IoC;
using Demo.Core.Infra.CrossCutting.IoC.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Demo.InvoiceImporter.Infra.Data.IoC
{
    public class DefaultBootstrapper
        : BootstrapperBase
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
            return new List<TypeRegistration>().ToArray();
        }
    }
}

using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.IoC;
using Demo.Core.Infra.CrossCutting.IoC.Models;
using Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands;
using Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices;
using Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.IoC
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
            return new[] {
                new TypeRegistration(typeof(IImportInvoiceAppService), typeof(ImportInvoiceAppService)),
                new TypeRegistration(typeof(IImportInvoiceCommandAdapter), typeof(ImportInvoiceCommandAdapter))
            };
        }
    }
}

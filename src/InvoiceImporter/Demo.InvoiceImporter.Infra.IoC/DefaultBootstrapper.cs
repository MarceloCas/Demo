using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.InvoiceImporter.Domain.Commands.Invoices;
using Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo.InvoiceImporter.Infra.IoC
{
    public class DefaultBootstrapper
    {
        public void RegisterServices(IServiceCollection services, string tenantCode, string cultureName, LocalizationsEnum localization)
        {
            new Core.Infra.CrossCutting.IoC.DefaultBootstrapper().RegisterServices(services, cultureName, localization);
            new Core.Domain.IoC.DefaultBootstrapper().RegisterServices(services, tenantCode);
            new Domain.IoC.DefaultBootstrapper().RegisterServices(services);
            new Data.IoC.DefaultBootstrapper().RegisterServices(services);

            RegisterHandlerRegistration(services);
        }

        protected void RegisterHandlerRegistration(IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationHandler, DefaultDomainNotificationHandler>();
            ConfigureRegistrationPipeline(services);
        }

        private void ConfigureRegistrationPipeline(IServiceCollection services)
        {
            services.AddScoped<IHandlerRegistrationManager>(q =>
            {
                var registrationManager = new HandlerRegistrationManager();

                registrationManager.RegisterDomainNotificationHandler(typeof(DomainNotification), typeof(DefaultDomainNotificationHandler), 1, false);
                
                registrationManager.RegisterCommandHandler(typeof(ImportInvoiceCommand), typeof(ImportInvoiceCommandHandler), 1, false, false);

                return registrationManager;
            });
        }
    }
}

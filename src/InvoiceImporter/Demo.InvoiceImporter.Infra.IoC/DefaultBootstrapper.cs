using Demo.Core.Domain.Queries.DomainModelsBase;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers;
using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.IoC;
using Demo.Core.Infra.CrossCutting.IoC.Models;
using Demo.InvoiceImporter.Domain.Commands.Invoices;
using Demo.InvoiceImporter.Domain.DomainModels;
using Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice;
using Demo.InvoiceImporter.Domain.Queries.Customers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Demo.InvoiceImporter.Infra.IoC
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

        // Public Methods
        public override TypeRegistration[] GetTypeRegistrationCollection()
        {
            return RegisterServices();
        }

        public virtual TypeRegistration[] RegisterServices()
        {
            var typeRegistrationCollection = new List<TypeRegistration>();

            typeRegistrationCollection.AddRange(new Core.Domain.IoC.DefaultBootstrapper(Services, TenantCode, CultureName, Localization).TypeRegistrationCollection);
            typeRegistrationCollection.AddRange(new Domain.IoC.DefaultBootstrapper(Services, TenantCode, CultureName, Localization).TypeRegistrationCollection);
            typeRegistrationCollection.AddRange(new Data.IoC.DefaultBootstrapper(Services, TenantCode, CultureName, Localization).TypeRegistrationCollection);
            typeRegistrationCollection.AddRange(ConfigureRegistrationPipeline());
            /*
             * In memory Bus need all type registrations. because this, the IBus must be the last registration
             */
            typeRegistrationCollection.Add(new TypeRegistration(
                    typeof(IBus),
                    serviceProvider =>
                    {
                        return new InMemoryBus(serviceProvider, typeRegistrationCollection.ToArray());
                    }
                ));

            return typeRegistrationCollection.ToArray();
        }

        private TypeRegistration[] ConfigureRegistrationPipeline()
        {
            return new[]
            {
                new TypeRegistration(typeof(IHandlerRegistrationManager), new Func<IServiceProvider, object>(q =>
                {
                    var registrationManager = new HandlerRegistrationManager();

                    // Domain Notification Handlers
                    registrationManager.RegisterDomainNotificationHandler(typeof(DomainNotification), typeof(InMemoryDefaultDomainNotificationHandler), 1, false);

                    // Command Handlers
                    registrationManager.RegisterCommandHandler(typeof(ImportInvoiceCommand), typeof(ImportInvoiceCommandHandler), 1, false, false);

                    // Query Handlers
                    registrationManager.RegisterQueryHandler(typeof(GetCustomerByGovernamentalDocumentNumberQuery), typeof(Domain.Handlers.Queries.Customers.GetCustomerByGovernamentalDocumentNumberQueryHandler), 1, false, false);
                    registrationManager.RegisterQueryHandler(typeof(GetDomainModelByIdQuery<Customer>), typeof(Domain.Handlers.Queries.Customers.GetDomainModelByIdQueryHandler), 1, false, false);
                    registrationManager.RegisterQueryHandler(typeof(GetDomainModelByIdQuery<Invoice>), typeof(Domain.Handlers.Queries.Invoices.GetDomainModelByIdQueryHandler), 1, false, false);

                    return registrationManager;
                }))
            };
        }
    }
}

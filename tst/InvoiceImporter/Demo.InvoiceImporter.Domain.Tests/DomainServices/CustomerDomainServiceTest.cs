using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.InvoiceImporter.Domain.Commands.Invoices;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Tests.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.InvoiceImporter.Domain.Tests.DomainServices
{
    public class CustomerDomainServiceTest
        : TestBase<CustomerDomainService>
    {
        public CustomerDomainServiceTest(
            ITestOutputHelper output,
            string tenant = "dev",
            string creationUser = "unitTest",
            LocalizationsEnum localization = LocalizationsEnum.Brazil,
            string cultureName = "en-US") 
            : base(output, tenant, creationUser, localization, cultureName)
        {
            
        }


        [Fact]
        [Trait(nameof(CustomerDomainService), "ImportCustomer_Success")]
        public async Task ImportCustomer_Success()
        {
            await RunWithTelemetry(async () =>
            {
                var bus = ServiceProvider.GetService<IBus>();

                await bus.SendCommandAsync(new ImportInvoiceCommand());

                bus.Dispose();

                return true;
            },
            10_000);

            //await RunWithTelemetry(async () =>
            //{
            //    var customerDomainService = ServiceProvider.GetService<ICustomerDomainService>();
            //    var customerFactory = ServiceProvider.GetService<ICustomerFactory>();

            //    var customerToImport = customerFactory.Create();
            //    var importedCustomer = await customerDomainService.ImportCustomerAsync(Tenant, CreationUser, customerToImport);

            //    var domainNotificationHandler = ServiceProvider.GetService<IDomainNotificationHandler>();
            //    _ = domainNotificationHandler.DomainNotificationsCollection;

            //    return true;
            //},
            //1);
        }
    }
}

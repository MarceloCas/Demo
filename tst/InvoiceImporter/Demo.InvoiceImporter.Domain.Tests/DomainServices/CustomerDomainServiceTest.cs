using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Tests.Base;
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
                var customerDomainService = Bootstrapper.GetService<ICustomerDomainService>();
                var customerFactory = Bootstrapper.GetService<ICustomerFactory>();
                var domainNotificationHandler = Bootstrapper.GetService<IInMemoryDefaultDomainNotificationHandler>();

                var customerToImport = await customerFactory.CreateAsync();
                var importedCustomer = await customerDomainService.ImportCustomerAsync(TenantCode, CreationUser, customerToImport);

                _ = domainNotificationHandler.DomainNotificationsCollection;

                return true;
            },
            1);
        }

    }
}

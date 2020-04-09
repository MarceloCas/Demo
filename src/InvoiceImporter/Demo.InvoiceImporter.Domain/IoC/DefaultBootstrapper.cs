using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using Demo.Core.Infra.CrossCutting.Globalization;
using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.IoC;
using Demo.Core.Infra.CrossCutting.IoC.Models;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer.BrazilianCustomer;
using static Demo.InvoiceImporter.Domain.DomainModels.Invoice;
using static Demo.InvoiceImporter.Domain.DomainModels.InvoiceItem;
using static Demo.InvoiceImporter.Domain.DomainModels.Product;
using static Demo.InvoiceImporter.Domain.Queries.Customers.GetCustomerByGovernamentalDocumentNumberQuery;

namespace Demo.InvoiceImporter.Domain.IoC
{
    public class DefaultBootstrapper
        : BootstrapperBase
    {
        // Constructors
        public DefaultBootstrapper(
            IServiceCollection services, 
            string tenantCode, 
            string cultureName, 
            LocalizationsEnum localization
            ) 
            : base(services, tenantCode, cultureName, localization)
        {
        }

        // Private Methods
        private TypeRegistration[] RegisterDomainModelsSpecifications()
        {
            return new[] {
                new TypeRegistration(typeof(ICustomerGovernamentalDocumentNumberMustBeUniqueSpecification), typeof(CustomerGovernamentalDocumentNumberMustBeUniqueSpecification)),
                new TypeRegistration(typeof(ICustomerMustHaveNameSpecification), typeof(CustomerMustHaveNameSpecification)),
                new TypeRegistration(typeof(ICustomerMustHaveNameWithValidLengthSpecification), typeof(CustomerMustHaveNameWithValidLengthSpecification)),
                new TypeRegistration(typeof(ICustomerMustHaveGovernamentalDocumentNumberSpecification), typeof(CustomerMustHaveGovernamentalDocumentNumberSpecification)),
                new TypeRegistration(typeof(ICustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification), typeof(CustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification)),
                new TypeRegistration(typeof(ICustomerMustHaveValidGovernamentalDocumentNumberSpecification), typeof(CustomerMustHaveValidGovernamentalDocumentNumberSpecification)),
                new TypeRegistration(
                    typeof(IGlobalizationConfig),
                    serviceProvider =>
                    {
                        return new GlobalizationConfig(CultureName, Localization);
                    }
                ),
                new TypeRegistration(
                    typeof(IInMemoryDefaultDomainNotificationHandler),
                    typeof(InMemoryDefaultDomainNotificationHandler)
                )
            };
        }
        private TypeRegistration[] RegisterDomainModelsValidations()
        {
            return new[] {
                new TypeRegistration(typeof(ICustomerIsValidForImportValidation), typeof(CustomerIsValidForImportValidation))
            };
        }
        private TypeRegistration[] RegisterAdapters()
        {
            return new[] {
                new TypeRegistration(typeof(IGetCustomerByGovernamentalDocumentNumberQueryAdapter), typeof(GetCustomerByGovernamentalDocumentNumberQueryAdapter))
            };
        }
        private TypeRegistration[] RegisterFactories()
        {
            return new[] {
                // DomainModels
                new TypeRegistration(typeof(ICustomerFactory), typeof(CustomerFactory)),
                new TypeRegistration(typeof(IBrazilianCustomerFactory), typeof(BrazilianCustomerFactory)),
                new TypeRegistration(typeof(IProductFactory), typeof(ProductFactory)),
                new TypeRegistration(typeof(IInvoicetItemFactory), typeof(InvoicetItemFactory)),
                new TypeRegistration(typeof(IInvoiceFactory), typeof(InvoiceFactory)),
                // Queries
                new TypeRegistration(typeof(IGetCustomerByGovernamentalDocumentNumberQueryFactory), typeof(GetCustomerByGovernamentalDocumentNumberQueryFactory))
            };
        }
        private TypeRegistration[] RegisterDomainServices()
        {
            return new[] {
                new TypeRegistration(typeof(ICustomerDomainService), typeof(CustomerDomainService)),
                new TypeRegistration(typeof(IInvoiceDomainService), typeof(InvoiceDomainService)),
                new TypeRegistration(typeof(IProductDomainService), typeof(ProductDomainService))
            };
        }
        private TypeRegistration[] RegisterDomainNotificationHandlers()
        {
            return new[] {
                new TypeRegistration(typeof(InMemoryDefaultDomainNotificationHandler))
            };
        }
        private TypeRegistration[] RegisterCommandHandlers()
        {
            return new[] {
                new TypeRegistration(typeof(ImportInvoiceCommandHandler))
            };
        }
        private TypeRegistration[] RegisterQueryHandlers()
        {
            return new[] {
                // Customers
                new TypeRegistration(typeof(Handlers.Queries.Customers.GetCustomerByGovernamentalDocumentNumberQueryHandler)),
                new TypeRegistration(typeof(Handlers.Queries.Customers.GetDomainModelByIdQueryHandler)),
                // Invoices
                new TypeRegistration(typeof(Handlers.Queries.Invoices.GetDomainModelByIdQueryHandler))
            };
        }

        // Public Methods
        public override TypeRegistration[] GetTypeRegistrationCollection()
        {
            var typeRegistrationCollection = new List<TypeRegistration>();

            typeRegistrationCollection.AddRange(RegisterDomainModelsSpecifications());
            typeRegistrationCollection.AddRange(RegisterDomainModelsValidations());
            typeRegistrationCollection.AddRange(RegisterAdapters());
            typeRegistrationCollection.AddRange(RegisterFactories());
            typeRegistrationCollection.AddRange(RegisterDomainServices());

            typeRegistrationCollection.AddRange(RegisterDomainNotificationHandlers());
            typeRegistrationCollection.AddRange(RegisterCommandHandlers());
            typeRegistrationCollection.AddRange(RegisterQueryHandlers());

            return typeRegistrationCollection.ToArray();
        }
    }
}

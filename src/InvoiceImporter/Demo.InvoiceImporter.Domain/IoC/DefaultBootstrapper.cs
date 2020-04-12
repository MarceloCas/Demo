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
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.InvoiceItems;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.InvoiceItems.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Invoices.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Products;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Products.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Invoices;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Invoices.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Products;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Products.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Events.Customers.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.Events.Invoices.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.Events.Products.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Products.Adapters;
using Demo.InvoiceImporter.Domain.Queries.Products.Adapters.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Products.Factories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer.BrazilianCustomer;
using static Demo.InvoiceImporter.Domain.DomainModels.Invoice;
using static Demo.InvoiceImporter.Domain.DomainModels.InvoiceItem;
using static Demo.InvoiceImporter.Domain.DomainModels.Product;
using static Demo.InvoiceImporter.Domain.Events.Customers.CustomerWasImportedEvent;
using static Demo.InvoiceImporter.Domain.Events.Customers.CustomerWasUpdatedEvent;
using static Demo.InvoiceImporter.Domain.Events.Invoices.InvoiceWasImportedEvent;
using static Demo.InvoiceImporter.Domain.Events.Products.ProductWasImportedEvent;
using static Demo.InvoiceImporter.Domain.Events.Products.ProductWasUpdatedEvent;
using static Demo.InvoiceImporter.Domain.Queries.Customers.GetCustomerByGovernamentalDocumentNumberQuery;
using static Demo.InvoiceImporter.Domain.Queries.Products.GetProductByCodeQuery;

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
                // Customers
                new TypeRegistration(typeof(ICustomerGovernamentalDocumentNumberMustBeUniqueSpecification), typeof(CustomerGovernamentalDocumentNumberMustBeUniqueSpecification)),
                new TypeRegistration(typeof(ICustomerMustHaveNameSpecification), typeof(CustomerMustHaveNameSpecification)),
                new TypeRegistration(typeof(ICustomerMustHaveNameWithValidLengthSpecification), typeof(CustomerMustHaveNameWithValidLengthSpecification)),
                new TypeRegistration(typeof(ICustomerMustHaveGovernamentalDocumentNumberSpecification), typeof(CustomerMustHaveGovernamentalDocumentNumberSpecification)),
                new TypeRegistration(typeof(ICustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification), typeof(CustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification)),
                new TypeRegistration(typeof(ICustomerMustHaveValidGovernamentalDocumentNumberSpecification), typeof(CustomerMustHaveValidGovernamentalDocumentNumberSpecification)),

                // Products
                new TypeRegistration(typeof(IProductMustHaveCodeSpecification), typeof(ProductMustHaveCodeSpecification)),
                new TypeRegistration(typeof(IProductMustHaveCodeWithValidLengthSpecification), typeof(ProductMustHaveCodeWithValidLengthSpecification)),
                new TypeRegistration(typeof(IProductMustHaveNameSpecification), typeof(ProductMustHaveNameSpecification)),
                new TypeRegistration(typeof(IProductMustHaveNameWithValidLengthSpecification), typeof(ProductMustHaveNameWithValidLengthSpecification)),

                // Invoices
                new TypeRegistration(typeof(IInvoiceMustHaveCodeSpecification), typeof(InvoiceMustHaveCodeSpecification)),
                new TypeRegistration(typeof(IInvoiceMustHaveCodeWithValidLengthSpecification), typeof(InvoiceMustHaveCodeWithValidLengthSpecification)),
                new TypeRegistration(typeof(IInvoiceMustHaveCustomerSpecification), typeof(InvoiceMustHaveCustomerSpecification)),
                new TypeRegistration(typeof(IInvoiceMustHaveItensSpecification), typeof(InvoiceMustHaveItensSpecification)),
                new TypeRegistration(typeof(IInvoiceMustHaveValidDateSpecification), typeof(InvoiceMustHaveValidDateSpecification)),

                // InvoiceItems
                new TypeRegistration(typeof(IInvoiceItemMustHaveInvoiceSpecification), typeof(InvoiceItemMustHaveInvoiceSpecification)),
                new TypeRegistration(typeof(IInvoiceItemMustHaveProductSpecification), typeof(InvoiceItemMustHaveProductSpecification)),
                new TypeRegistration(typeof(IInvoiceItemMustHaveQuatityWithValidLengthSpecification), typeof(InvoiceItemMustHaveQuatityWithValidLengthSpecification)),
                new TypeRegistration(typeof(IInvoiceItemMustHaveUnitPriceWithValidLengthSpecification), typeof(InvoiceItemMustHaveUnitPriceWithValidLengthSpecification))

            };
        }
        private TypeRegistration[] RegisterDomainModelsValidations()
        {
            return new[] {
                new TypeRegistration(typeof(ICustomerIsValidForImportValidation), typeof(CustomerIsValidForImportValidation)),
                new TypeRegistration(typeof(IInvoiceIsValidForImportValidation), typeof(InvoiceIsValidForImportValidation)),
                new TypeRegistration(typeof(IProductIsValidForImportValidation), typeof(ProductIsValidForImportValidation))
            };
        }
        private TypeRegistration[] RegisterAdapters()
        {
            return new[] {
                new TypeRegistration(typeof(IGetCustomerByGovernamentalDocumentNumberQueryAdapter), typeof(GetCustomerByGovernamentalDocumentNumberQueryAdapter)),
                new TypeRegistration(typeof(IGetProductByCodeQueryAdapter), typeof(GetProductByCodeQueryAdapter))
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
                new TypeRegistration(typeof(IGetCustomerByGovernamentalDocumentNumberQueryFactory), typeof(GetCustomerByGovernamentalDocumentNumberQueryFactory)),
                new TypeRegistration(typeof(IGetProductByCodeQueryFactory), typeof(GetProductByCodeQueryFactory)),
                // Events
                new TypeRegistration(typeof(ICustomerWasImportedEventFactory), typeof(CustomerWasImportedEventFactory)),
                new TypeRegistration(typeof(ICustomerWasUpdatedEventFactory), typeof(CustomerWasUpdatedEventFactory)),
                new TypeRegistration(typeof(IInvoiceWasImportedEventFactory), typeof(InvoiceWasImportedEventFactory)),
                new TypeRegistration(typeof(IProductWasImportedEventFactory), typeof(ProductWasImportedEventFactory)),
                new TypeRegistration(typeof(IProductWasUpdatedEventFactory), typeof(ProductWasUpdatedEventFactory))
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

            typeRegistrationCollection.AddRange(new[] {
                new TypeRegistration(
                    typeof(IGlobalizationConfig),
                    serviceProvider =>
                    {
                        return new GlobalizationConfig(CultureName, Localization);
                    }
                ),
                new TypeRegistration(
                    typeof(IInMemoryDefaultDomainNotificationHandler),
                    serviceProvider => {

                        /*
                         * All Handlers (Domain Notifications, Command, Query and Events)
                         * are registered without a interface type because HandlerRegistration.
                         * because this, a IInMemoryDefaultDomainNotificationHandler interface
                         * must be registered with a existing InMemoryDefaultDomainNotificationHandler
                         * instance
                         */

                        return (InMemoryDefaultDomainNotificationHandler)
                            serviceProvider.GetService(typeof(InMemoryDefaultDomainNotificationHandler));
                    }
                )
            });

            return typeRegistrationCollection.ToArray();
        }
    }
}

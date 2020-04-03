using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers;
using Demo.InvoiceImporter.Domain.DomainModels.Specifications.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers;
using Demo.InvoiceImporter.Domain.DomainModels.Validations.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice;
using Demo.InvoiceImporter.Domain.Handlers.Commands.Invoice.Interfaces;
using Demo.InvoiceImporter.Domain.Handlers.Queries.Customers;
using Demo.InvoiceImporter.Domain.Handlers.Queries.Customers.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters;
using Demo.InvoiceImporter.Domain.Queries.Customers.Adapters.Interfaces;
using Demo.InvoiceImporter.Domain.Queries.Customers.Factories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer.BrazilianCustomer;
using static Demo.InvoiceImporter.Domain.DomainModels.Invoice;
using static Demo.InvoiceImporter.Domain.DomainModels.InvoiceItem;
using static Demo.InvoiceImporter.Domain.DomainModels.Product;
using static Demo.InvoiceImporter.Domain.Queries.Customers.GetCustomerByGovernamentalDocumentNumberQuery;
using static Demo.InvoiceImporter.Domain.Queries.Customers.GetCustomerByIdQuery;

namespace Demo.InvoiceImporter.Domain.IoC
{
    public class DefaultBootstrapper
    {
        public void RegisterServices(IServiceCollection services)
        {
            RegisterDomainModelsSpecifications(services);
            RegisterDomainModelsValidations(services);
            RegisterAdapters(services);
            RegisterFactories(services);
            RegisterDomainServices(services);
            RegisterCommandHandlers(services);
            RegisterQueryHandlers(services);
        }

        private void RegisterDomainModelsSpecifications(IServiceCollection services)
        {
            services.AddScoped<ICustomerGovernamentalDocumentNumberMustBeUniqueSpecification, CustomerGovernamentalDocumentNumberMustBeUniqueSpecification>();
            services.AddScoped<ICustomerMustHaveNameSpecification, CustomerMustHaveNameSpecification>();
            services.AddScoped<ICustomerMustHaveNameWithValidLengthSpecification, CustomerMustHaveNameWithValidLengthSpecification>();
            services.AddScoped<ICustomerMustHaveGovernamentalDocumentNumberSpecification, CustomerMustHaveGovernamentalDocumentNumberSpecification>();
            services.AddScoped<ICustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification, CustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification>();
            services.AddScoped<ICustomerMustHaveValidGovernamentalDocumentNumberSpecification, CustomerMustHaveValidGovernamentalDocumentNumberSpecification>();
        }
        private void RegisterDomainModelsValidations(IServiceCollection services)
        {
            services.AddScoped<ICustomerIsValidForImportValidation, CustomerIsValidForImportValidation>();
        }
        private void RegisterAdapters(IServiceCollection services)
        {
            services.AddScoped<IGetCustomerByIdQueryAdapter, GetCustomerByIdQueryAdapter>();
            services.AddScoped<IGetCustomerByGovernamentalDocumentNumberQueryAdapter, GetCustomerByGovernamentalDocumentNumberQueryAdapter>();
        }
        private void RegisterFactories(IServiceCollection services)
        {
            // DomainModels
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            services.AddScoped<IBrazilianCustomerFactory, BrazilianCustomerFactory>();
            services.AddScoped<IProductFactory, ProductFactory>();
            services.AddScoped<IInvoicetItemFactory, InvoicetItemFactory>();
            services.AddScoped<IInvoiceFactory, InvoiceFactory>();

            // Queries
            services.AddScoped<IGetCustomerByIdQueryFactory, GetCustomerByIdQueryFactory>();
            services.AddScoped<IGetCustomerByGovernamentalDocumentNumberQueryFactory, GetCustomerByGovernamentalDocumentNumberQueryFactory>();
        }
        private void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerDomainService, CustomerDomainService>();
            services.AddScoped<IInvoiceDomainService, InvoiceDomainService>();
            services.AddScoped<IProductDomainService, ProductDomainService>();
        }

        private void RegisterCommandHandlers(IServiceCollection services)
        {
            services.AddScoped<IImportInvoiceCommandHandler, ImportInvoiceCommandHandler>();
        }
        private void RegisterQueryHandlers(IServiceCollection services)
        {
            services.AddScoped<IGetDomainModelByIdQueryHandler, GetDomainModelByIdQueryHandler>();
        }
    }
}

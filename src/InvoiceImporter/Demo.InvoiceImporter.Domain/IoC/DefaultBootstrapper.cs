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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer.BrazilianCustomer;
using static Demo.InvoiceImporter.Domain.DomainModels.Invoice;
using static Demo.InvoiceImporter.Domain.DomainModels.InvoiceItem;
using static Demo.InvoiceImporter.Domain.DomainModels.Product;

namespace Demo.InvoiceImporter.Domain.IoC
{
    public class DefaultBootstrapper
    {
        public void RegisterServices(IServiceCollection services)
        {
            RegisterDomainModelsSpecifications(services);
            RegisterDomainModelsValidations(services);
            RegisterFactories(services);
            RegisterDomainServices(services);
            RegisterCommands(services);
        }

        private void RegisterDomainModelsSpecifications(IServiceCollection services)
        {
            services.AddScoped<ICustomerGovernamentalDocumentNumberMustBeUniqueSpecification, CustomerGovernamentalDocumentNumberMustBeUniqueSpecification>();
            services.AddScoped<ICustomerMustExistsSpecification, CustomerMustExistsSpecification>();
            services.AddScoped<ICustomerMustHaveNameSpecification, CustomerMustHaveNameSpecification>();
            services.AddScoped<ICustomerMustHaveNameWithValidLengthSpecification, CustomerMustHaveNameWithValidLengthSpecification>();
            services.AddScoped<ICustomerMustHaveGovernamentalDocumentNumberSpecification, CustomerMustHaveGovernamentalDocumentNumberSpecification>();
            services.AddScoped<ICustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification, CustomerMustHaveGovernamentalDocumentNumberWithValidLengthSpecification>();
            services.AddScoped<ICustomerMustHaveValidGovernamentalDocumentNumberSpecification, CustomerMustHaveValidGovernamentalDocumentNumberSpecification>();
            services.AddScoped<ICustomerMustNotExistsSpecification, CustomerMustNotExistsSpecification>();
        }
        private void RegisterDomainModelsValidations(IServiceCollection services)
        {
            services.AddScoped<ICustomerIsValidForImportValidation, CustomerIsValidForImportValidation>();
        }
        private void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            services.AddScoped<IBrazilianCustomerFactory, BrazilianCustomerFactory>();
            services.AddScoped<IProductFactory, ProductFactory>();
            services.AddScoped<IInvoicetItemFactory, InvoicetItemFactory>();
            services.AddScoped<IInvoiceFactory, InvoiceFactory>();
        }
        private void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerDomainService, CustomerDomainService>();
            services.AddScoped<IInvoiceDomainService, InvoiceDomainService>();
            services.AddScoped<IProductDomainService, ProductDomainService>();
        }
        private void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<IImportInvoiceCommandHandler, ImportInvoiceCommandHandler>();
        }
    }
}

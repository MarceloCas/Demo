using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using Demo.InvoiceImporter.Domain.DomainServices;
using Demo.InvoiceImporter.Domain.DomainServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer;
using static Demo.InvoiceImporter.Domain.DomainModels.Invoice;
using static Demo.InvoiceImporter.Domain.DomainModels.InvoiceItem;
using static Demo.InvoiceImporter.Domain.DomainModels.Product;

namespace Demo.InvoiceImporter.Domain.IoC
{
    public class DefaultBootstrapper
    {
        public void RegisterServices(IServiceCollection services)
        {
            RegisterFactories(services);
            RegisterDomainServices(services);
        }

        private void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<ICustomerFactory, CustomerFactory>();
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
    }
}

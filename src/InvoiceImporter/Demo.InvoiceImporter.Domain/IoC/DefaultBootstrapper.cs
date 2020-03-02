using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
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
    public static class DefaultBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            services.AddScoped<IProductFactory, ProductFactory>();
            services.AddScoped<IInvoicetItemFactory, InvoicetItemFactory>();
            services.AddScoped<IInvoiceFactory, InvoiceFactory>();
        }
    }
}

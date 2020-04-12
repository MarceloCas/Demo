using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Interfaces;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels
{
    public class Invoice
        : DomainModelBase,
        IInvoice<Customer, Product, InvoiceItem>
    {
        // Properties
        public string Code { get; protected set; }
        public DateTime Date { get; protected set; }
        public Customer Customer { get; protected set; }
        public ICollection<InvoiceItem> InvoiceItemCollection { get; protected set; }

        // Constructors
        protected Invoice() { }

        // Private Methods
        private Invoice SetCode(string code)
        {
            Code = code;
            return this;
        }
        private Invoice SetDate(DateTime datetime)
        {
            Date = datetime;
            return this;
        }
        private Invoice SetCustomer(Customer customer)
        {
            Customer = customer;
            return this;
        }
        private Invoice AddInvoiceItem(InvoiceItem invoiceItem)
        {
            if (!InvoiceItemCollection.Any(q => q.Product.Code.Equals(invoiceItem.Product.Code)))
            {
                var importedInvoiceItem = invoiceItem.ImportInvoiceItem(
                    TenantCode,
                    this,
                    invoiceItem.Product,
                    invoiceItem.Sequence,
                    invoiceItem.Quantity,
                    invoiceItem.UnitPrice,
                    CreationUser);

                InvoiceItemCollection.Add(importedInvoiceItem);
            }

            return this;
        }
        private Invoice AddInvoiceItemRange(ICollection<InvoiceItem> invoiceItemCollection)
        {
            foreach (var invoiceItem in invoiceItemCollection)
                AddInvoiceItem(invoiceItem);

            return this;
        }

        // Public Methods
        public Invoice ImportInvoice(
            string tenantCode,
            string code,
            DateTime date,
            Customer customer,
            ICollection<InvoiceItem> invoiceItemCollection,
            string creationUser)
        {
            GenerateNewId();
            SetCode(code);
            SetDate(date);
            SetCustomer(customer);
            AddInvoiceItemRange(invoiceItemCollection);
            SetTenantCode(tenantCode);
            SetCreationInfo(creationUser);

            return this;
        }

        #region Factories
        public class InvoiceFactory
            : DomainModelBaseFactory<Invoice>,
            IInvoiceFactory
        {
            private readonly ICustomerFactory _customerFactory;

            public InvoiceFactory(
                ITenantInfoValueObjectFactory tenantInfoValueObjectFactory,
                IGlobalizationConfig globalizationConfig,
                ICustomerFactory customerFactory
                ) 
                : base(tenantInfoValueObjectFactory, globalizationConfig)
            {
                _customerFactory = customerFactory;
            }

            public override async Task<Invoice> CreateAsync()
            {
                return await RegisterBaseTypesAsync(new Invoice
                {
                    Customer = await _customerFactory.CreateAsync(),
                    InvoiceItemCollection = new List<InvoiceItem>()
                });
            }
        }
        #endregion
    }
}

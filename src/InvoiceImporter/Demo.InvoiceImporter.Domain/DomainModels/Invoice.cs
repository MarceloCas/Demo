using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Interfaces;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.Commands.Invoices.ImportInvoice;
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
        public string Code { get; private set; }
        public DateTime Date { get; private set; }
        public Customer Customer { get; private set; }
        public ICollection<InvoiceItem> InvoiceItemCollection { get; private set; }

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
            if (invoiceItemCollection != null)
                foreach (var invoiceItem in invoiceItemCollection)
                    AddInvoiceItem(invoiceItem);

            return this;
        }

        // Protected Methods
        protected override string GetSummary()
        {
            return $"Invoice: {Code}";
        }

        // Public Methods
        public Invoice SetCustomer(Customer customer)
        {
            Customer = customer;
            return this;
        }
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
            private readonly IInvoiceItemFactory _invoiceItemFactory;
            private readonly IProductFactory _productFactory;

            public InvoiceFactory(
                ITenantInfoValueObjectFactory tenantInfoValueObjectFactory,
                IGlobalizationConfig globalizationConfig,
                ICustomerFactory customerFactory,
                IInvoiceItemFactory invoiceItemFactory,
                IProductFactory productFactory
                )
                : base(tenantInfoValueObjectFactory, globalizationConfig)
            {
                _customerFactory = customerFactory;
                _invoiceItemFactory = invoiceItemFactory;
                _productFactory = productFactory;
            }

            public override async Task<Invoice> CreateAsync()
            {
                return await RegisterBaseTypesAsync(new Invoice
                {
                    Customer = await _customerFactory.CreateAsync(),
                    InvoiceItemCollection = new List<InvoiceItem>()
                });
            }

            public async Task<Invoice> CreateAsync(ImportInvoiceCommand parameter)
            {
                var importedInvoice = await CreateAsync();
                importedInvoice = importedInvoice.ImportInvoice(
                    importedInvoice.TenantCode,
                    parameter?.Code,
                    parameter?.Date ?? DateTime.MinValue,
                    await _customerFactory.CreateAsync(parameter),
                    null,
                    parameter.RequestUser
                );

                foreach (var invoiceItem in parameter.InvoiceItemCollection)
                {
                    var newInvoiceItem = await _invoiceItemFactory.CreateAsync();

                    newInvoiceItem = newInvoiceItem.ImportInvoiceItem(
                            newInvoiceItem.TenantCode,
                            importedInvoice,
                            await _productFactory.CreateAsync(invoiceItem.Product),
                            invoiceItem.Sequence,
                            invoiceItem.Quantity,
                            invoiceItem.UnitPrice,
                            parameter.RequestUser
                    );

                    importedInvoice.AddInvoiceItem(newInvoiceItem);
                }

                return importedInvoice;
            }
        }
        #endregion
    }
}

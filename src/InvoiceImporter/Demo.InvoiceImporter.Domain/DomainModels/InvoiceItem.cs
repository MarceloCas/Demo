using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Interfaces;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels
{
    public class InvoiceItem
        : DomainModelBase,
        IInvoiceItem<Product>
    {
        // Properties
        public Invoice Invoice { get; protected set; }
        public Product Product { get; protected set; }
        public int Sequence { get; protected set; }
        public double Quantity { get; protected set; }
        public double UnitPrice { get; protected set; }

        // Constructors
        protected InvoiceItem() { }
        
        // Private methods
        private InvoiceItem SetProduct(Product product)
        {
            Product = product;
            return this;
        }
        private InvoiceItem SetSequence(int sequence)
        {
            Sequence = sequence;
            return this;
        }
        private InvoiceItem SetQuantity(double quantity)
        {
            Quantity = quantity;
            return this;
        }
        private InvoiceItem SetUnitPrice(double unitPrice)
        {
            UnitPrice = unitPrice;
            return this;
        }

        // Public methods
        public InvoiceItem SetInvoice(Invoice invoice)
        {
            Invoice = invoice;

            return this;
        }
        public InvoiceItem ImportInvoiceItem(
            string tenantCode, 
            Invoice invoice,
            Product product,
            int sequence,
            double quantity, 
            double unitPrice, 
            string creationUser)
        {
            GenerateNewId();
            SetTenantCode(tenantCode);
            SetInvoice(invoice);
            SetProduct(product);
            SetSequence(sequence);
            SetQuantity(quantity);
            SetUnitPrice(unitPrice);
            SetCreationInfo(creationUser);

            return this;
        }

        #region Factories
        public class InvoicetItemFactory
            : DomainModelBaseFactory<InvoiceItem>,
            IInvoicetItemFactory
        {
            private readonly IProductFactory _productFactory;

            public InvoicetItemFactory(
                IProductFactory productFactory,
                ITenantInfoValueObjectFactory tenantInfoValueObjectFactory,
                IGlobalizationConfig globalizationConfig)
                : base(tenantInfoValueObjectFactory, globalizationConfig)
            {
                _productFactory = productFactory;
            }

            public override async Task<InvoiceItem> CreateAsync()
            {
                return await RegisterBaseTypesAsync(new InvoiceItem
                {
                    Product = await _productFactory.CreateAsync()
                });
            }
        }
        #endregion
    }
}

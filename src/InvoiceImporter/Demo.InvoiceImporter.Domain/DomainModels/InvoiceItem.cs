using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Interfaces;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainModels
{
    public class InvoiceItem
        : DomainModelBase,
        IInvoiceItem<Product>
    {
        // Properties
        public Invoice Invoice { get; protected set; }
        public Product Product { get; protected set; }
        public double Quantity { get; protected set; }
        public double UnitPrice { get; protected set; }

        // Constructors
        protected InvoiceItem() { }
        
        // Private methods
        private InvoiceItem GenerateNewId()
        {
            Id = Guid.NewGuid();
            return this;
        }
        private InvoiceItem SetProduct(Product product)
        {
            Product = product;
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
            Product product, 
            double quantity, 
            double unitPrice, 
            string creationUser)
        {
            GenerateNewId();
            SetProduct(product);
            SetQuantity(quantity);
            SetUnitPrice(unitPrice);
            SetCreationInfo(tenantCode, creationUser);

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

            public override InvoiceItem Create()
            {
                return RegisterBaseTypes(new InvoiceItem
                {
                    Product = _productFactory.Create()
                });
            }
        }
        #endregion
    }
}

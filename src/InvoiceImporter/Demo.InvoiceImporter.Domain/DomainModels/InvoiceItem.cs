using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Interfaces;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels
{
    public class InvoiceItem
        : DomainModelBase,
        IInvoiceItem<Product>
    {
        // Properties
        public Invoice Invoice { get; private set; }
        public Product Product { get; private set; }
        public int Sequence { get; private set; }
        public double Quantity { get; private set; }
        public double UnitPrice { get; private set; }

        // Constructors
        protected InvoiceItem() { }
        
        // Private methods
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
        public InvoiceItem SetProduct(Product product)
        {
            Product = product;
            return this;
        }
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
        public class InvoiceItemFactory
            : DomainModelBaseFactory<InvoiceItem>,
            IInvoiceItemFactory
        {
            private readonly IProductFactory _productFactory;

            public InvoiceItemFactory(
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

            public async Task<InvoiceItem> CreateAsync(Commands.Invoices.ImportInvoice.InvoiceItem parameter)
            {
                var invoiceItem = await CreateAsync();

                invoiceItem.SetSequence(parameter?.Sequence ?? -1);
                invoiceItem.SetQuantity(parameter?.Quantity ?? -1);
                invoiceItem.SetUnitPrice(parameter?.UnitPrice ?? -1);

                return invoiceItem;
            }
        }
        #endregion
    }
}

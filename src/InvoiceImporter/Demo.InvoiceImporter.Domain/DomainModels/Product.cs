using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Interfaces;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainModels
{
    public class Product
        : DomainModelBase,
        IProduct
    {
        // Properties
        public string Name { get; protected set; }
        public string Code { get; protected set; }

        // Constructors
        protected Product() { }

        // Private Methods
        private Product SetName(string name)
        {
            Name = name;
            return this;
        }
        private Product SetCode(string code)
        {
            Code = code;
            return this;
        }

        // Public methods
        public Product ImportProduct(string tenantCode, string name, string code, string creationUser)
        {
            GenerateNewId();
            SetName(name);
            SetCode(code);
            SetTenantCode(tenantCode);
            SetCreationInfo(creationUser);

            return this;
        }

        #region Factories
        public class ProductFactory
            : DomainModelBaseFactory<Product>,
            IProductFactory
        {
            public ProductFactory(
                ITenantInfoValueObjectFactory tenantInfoValueObjectFactory,
                IGlobalizationConfig globalizationConfig) 
                : base(tenantInfoValueObjectFactory, globalizationConfig)
            {

            }

            public override async Task<Product> CreateAsync()
            {
                return await RegisterBaseTypesAsync(new Product());
            }
        }
        #endregion
    }
}

using Demo.Core.Domain.ValueObjects.Base;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;

namespace Demo.Core.Domain.ValueObjects
{
    public class TenantInfoValueObject
        : ValueObjectBase
    {
        public string TenantCode { get; protected set; }

        protected TenantInfoValueObject()
        {

        }

        public TenantInfoValueObject SetTenantCode(string tenantCode)
        {
            TenantCode = tenantCode;
            return this;
        }

        #region Factories
        public class TenantInfoValueObjectFactory
            : FactoryBase<TenantInfoValueObject>,
            ITenantInfoValueObjectFactory
        {
            public override TenantInfoValueObject Create()
            {
                return new TenantInfoValueObject();
            }

            public TenantInfoValueObject Create(string tenantCode)
            {
                return Create()
                    .SetTenantCode(tenantCode);
            }
        }
        #endregion
    }
}

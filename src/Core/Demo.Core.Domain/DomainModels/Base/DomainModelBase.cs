using Demo.Core.Domain.DomainModels.Base.Interfaces;
using Demo.Core.Domain.ValueObjects;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using System;

namespace Demo.Core.Domain.DomainModels.Base
{
    public abstract class DomainModelBase
        : IAuditableDomainModel
    {
        // Attributes
        private TenantInfoValueObject _tenantInfo;

        // Properties
        public Guid Id { get; protected set; }
        public string TenantCode
        {
            get
            {
                return _tenantInfo.TenantCode;
            }
            protected set
            {
                _tenantInfo.SetTenantCode(value);
            }
        }
        public string CreationUser { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public string ModificationUser { get; protected set; }
        public DateTime ModificationDate { get; protected set; }

        // Constructors
        protected DomainModelBase()
        {

        }

        // Public Methods
        protected void SetModificationInfo(
            string modificationUser)
        {
            ModificationUser = modificationUser;
            ModificationDate = DateTime.UtcNow;
        }
        protected void SetCreationInfo(
            string tenantCode,
            string creationUser,
            string modificationUser = null)
        {
            TenantCode = tenantCode;
            CreationUser = creationUser;

            if (!string.IsNullOrWhiteSpace(modificationUser))
                SetModificationInfo(modificationUser);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region Factories
        public abstract class DomainModelBaseFactory<TDomainModelBase>
            : FactoryBase<TDomainModelBase>
            where TDomainModelBase : DomainModelBase
        {
            private readonly ITenantInfoValueObjectFactory _tenantInfoValueObjectFactory;

            protected DomainModelBaseFactory(ITenantInfoValueObjectFactory tenantInfoValueObjectFactory)
            {
                _tenantInfoValueObjectFactory = tenantInfoValueObjectFactory;
            }

            protected TDomainModelBase RegisterBaseTypes(TDomainModelBase domainModelBase)
            {
                domainModelBase._tenantInfo = _tenantInfoValueObjectFactory.Create();
                return domainModelBase;
            }
        }
        #endregion
    }
}

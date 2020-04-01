﻿using Demo.Core.Domain.DomainModels.Base.Interfaces;
using Demo.Core.Domain.ValueObjects;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

            protected DomainModelBaseFactory(
                ITenantInfoValueObjectFactory tenantInfoValueObjectFactory,
                IGlobalizationConfig globalizationConfig)
                : base(globalizationConfig)
            {
                _tenantInfoValueObjectFactory = tenantInfoValueObjectFactory;
            }

            protected async Task<TDomainModelBase> RegisterBaseTypesAsync(TDomainModelBase domainModelBase)
            {
                domainModelBase._tenantInfo = await _tenantInfoValueObjectFactory.CreateAsync();
                return domainModelBase;
            }
        }
        #endregion
    }
}

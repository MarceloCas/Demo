﻿using Demo.Core.Domain.ValueObjects.Base;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            private readonly string _tenantCode;

            public TenantInfoValueObjectFactory(
                IGlobalizationConfig globalizationConfig,
                string tenantCode) 
                : base(globalizationConfig)
            {
                _tenantCode = tenantCode;
            }

            public override TenantInfoValueObject Create()
            {
                var tenantInfo = new TenantInfoValueObject();
                tenantInfo.SetTenantCode(_tenantCode);

                return tenantInfo;
            }
        }
        #endregion
    }
}

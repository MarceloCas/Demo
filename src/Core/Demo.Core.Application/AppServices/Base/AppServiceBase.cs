using Demo.Core.Application.AppServices.Interfaces;
using Demo.Core.Domain.ValueObjects;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System;

namespace Demo.Core.Application.AppServices.Base
{
    public abstract class AppServiceBase
        : IAppService
    {
        // Properties
        protected IBus Bus { get; }
        protected IGlobalizationConfig GlobalizationConfig { get; }
        protected TenantInfoValueObject TenantInfoValueObject { get; }


        // Constructors
        protected AppServiceBase(
            IBus bus,
            IGlobalizationConfig globalizationConfig,
            ITenantInfoValueObjectFactory tenantInfoValueObjectFactory
            )
        {
            Bus = bus;
            GlobalizationConfig = globalizationConfig;
            TenantInfoValueObject = tenantInfoValueObjectFactory.CreateAsync().GetAwaiter().GetResult();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

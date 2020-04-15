using Demo.Core.Application.AppServices.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using System;

namespace Demo.Core.Application.AppServices.Base
{
    public abstract class AppServiceBase
        : IAppService
    {
        // Attributes
        private readonly IBus _bus;

        // Properties
        public IBus Bus
        {
            get
            {
                return _bus;
            }
        }

        // Constructors
        protected AppServiceBase(
            IBus bus
            )
        {
            _bus = bus;
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

using Demo.Core.Application.AppServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Application.AppServices.Base
{
    public abstract class AppServiceBase
        : IAppService
    {

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

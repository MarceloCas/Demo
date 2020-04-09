using System;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter
{
    public abstract class AdapterBase
        : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

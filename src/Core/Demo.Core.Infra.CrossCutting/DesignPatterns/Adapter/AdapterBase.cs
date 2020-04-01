using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

using Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter
{
    public abstract class AdapterBase<TTo, TFrom>
        : IAdapter<TTo, TFrom>
    {
        public abstract TTo Adaptee(TFrom source);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

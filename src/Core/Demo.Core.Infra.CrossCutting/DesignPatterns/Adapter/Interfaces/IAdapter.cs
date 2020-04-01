using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter.Interfaces
{
    public interface IAdapter<TTo, TFrom>
        : IDisposable
    {
        TTo Adaptee(TFrom source);
    }
}

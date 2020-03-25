using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces
{
    public interface IFactoryWithParameters<TReturn, TParameter>
        : IFactory<TReturn>
    {
        TReturn Create(TParameter parameter);
    }
}

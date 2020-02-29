using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base
{
    public abstract class FactoryBase<TReturn>
        : IFactory<TReturn>
    {
        public abstract TReturn Create();
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base
{
    public abstract class FactoryBase<TReturn>
        : IFactory<TReturn>
    {
        public abstract TReturn Create();
    }
}

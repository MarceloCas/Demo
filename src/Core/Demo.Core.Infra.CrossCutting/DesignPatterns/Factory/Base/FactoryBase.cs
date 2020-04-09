using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base
{
    public abstract class FactoryBase<TReturn>
        : IFactory<TReturn>
    {
        // Attributes
        private readonly IGlobalizationConfig _globalizationConfig;

        // Properties
        protected IGlobalizationConfig GlobalizationConfig
        {
            get
            {
                return _globalizationConfig;
            }
        }

        // Constructors
        protected FactoryBase(IGlobalizationConfig globalizationConfig)
        {
            _globalizationConfig = globalizationConfig;
        }

        // Public Methods
        public abstract Task<TReturn> CreateAsync();
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

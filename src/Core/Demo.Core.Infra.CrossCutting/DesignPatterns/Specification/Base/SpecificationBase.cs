using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System.Threading.Tasks;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base
{
    public abstract class SpecificationBase<T>
        : ISpecification<T>
    {
        // Attributes
        private readonly IBus _bus;
        private readonly IGlobalizationConfig _globalizationConfig;

        // Properties
        public string ErrorCode { get; set; }
        public string ErrorDefaultDescription { get; set; }

        protected IBus Bus {  get { return _bus; } }
        protected IGlobalizationConfig GlobalizationConfig { get { return _globalizationConfig; } }

        // Constructors
        protected SpecificationBase(
            IBus bus,
            IGlobalizationConfig globalizationConfig)
        {
            _bus = bus;
            _globalizationConfig = globalizationConfig;
            ErrorCode = ErrorDefaultDescription = this.GetType().Name;
        }

        // Public Methods
        public abstract Task<bool> IsSatisfiedByAsync(T entity);
    }
}

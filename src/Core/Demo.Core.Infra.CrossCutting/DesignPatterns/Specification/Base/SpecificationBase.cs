using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System.Globalization;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base
{
    public abstract class SpecificationBase<T>
        : ISpecification<T>
    {
        private readonly IGlobalizationConfig _globalizationConfig;

        public string ErrorCode { get; set; }
        public string ErrorDefaultDescription { get; set; }

        protected IGlobalizationConfig GlobalizationConfig
        {
            get
            {
                return _globalizationConfig;
            }
        }

        protected SpecificationBase(
            IGlobalizationConfig globalizationConfig)
        {
            _globalizationConfig = globalizationConfig;
            ErrorCode = ErrorDefaultDescription = this.GetType().Name;
        }

        public abstract Task<bool> IsSatisfiedByAsync(T entity);
    }
}

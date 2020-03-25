using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base
{
    public abstract class SpecificationBase<T>
        : ISpecification<T>
    {
        public string ErrorCode { get; set; }
        public string ErrorDefaultDescription { get; set; }

        protected SpecificationBase()
        {
            ErrorCode = ErrorDefaultDescription = this.GetType().Name;
        }

        public abstract Task<bool> IsSatisfiedBy(T entity);
    }
}

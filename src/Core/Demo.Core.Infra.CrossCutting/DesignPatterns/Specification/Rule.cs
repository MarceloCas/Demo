using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System.Globalization;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationSpec;

        public string Code { get; private set; }
        public string DefaultDescription { get; private set; }

        public Rule(ISpecification<TEntity> spec, string code, string defaultDescription)
        {
            _specificationSpec = spec;
            Code = code;
            DefaultDescription = defaultDescription;
        }

        public async Task<bool> ValidateAsync(TEntity entity)
        {
            return await _specificationSpec.IsSatisfiedByAsync(entity);
        }
    }
}



using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification
{
    public abstract class Validator<TEntity> : IValidator<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRule<TEntity>> _validations = new Dictionary<string, IRule<TEntity>>();

        public virtual async Task<ValidationResult> ValidateAsync(TEntity entity)
        {
            var validationResult = new ValidationResult();
            foreach (var key in _validations.Keys)
            {
                var rule = _validations[key];
                if (await rule.ValidateAsync(entity) == false)
                {
                    validationResult.Add(new ValidationMessage(entity.ToString(), rule.Code, rule.DefaultDescription));
                }
            }

            await ExecutePostValidateAsync(entity, validationResult);

            return await Task.FromResult(validationResult);
        }

        protected virtual void AddSpecification(ISpecification<TEntity> specification)
        {
            var rule = new Rule<TEntity>(specification, specification.ErrorCode, specification.ErrorDefaultDescription);

            Add(specification.ErrorCode, rule);
        }

        protected virtual void Add(string name, IRule<TEntity> rule)
        {
            _validations.Add(name, rule);
        }

        protected virtual void Remove(string name)
        {
            _validations.Remove(name);
        }

        protected IRule<TEntity> GetRule(string name)
        {
            _validations.TryGetValue(name, out var value);
            return value;
        }

        protected abstract Task<bool> ExecutePostValidateAsync(TEntity entity, ValidationResult validationResult);
    }
}



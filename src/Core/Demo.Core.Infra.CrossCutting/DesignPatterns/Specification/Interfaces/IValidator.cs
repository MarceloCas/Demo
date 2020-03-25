using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces
{
    public interface IValidator<in TEntity>
    {
        Task<ValidationResult> Validate(TEntity entity);
    }
}



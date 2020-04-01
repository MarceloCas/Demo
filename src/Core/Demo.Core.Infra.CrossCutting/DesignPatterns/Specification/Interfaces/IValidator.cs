using System.Globalization;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces
{
    public interface IValidator<in TEntity>
    {
        Task<ValidationResult> ValidateAsync(TEntity entity);
    }
}



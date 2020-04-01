using System.Globalization;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces
{
    public interface IRule<in TEntity>
    {
        string Code { get; }
        string DefaultDescription { get; }

        Task<bool> ValidateAsync(TEntity entity);
    }
}



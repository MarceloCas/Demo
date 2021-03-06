using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces
{
    public interface ISpecification<in T>
    {
        string ErrorCode { get; }
        string ErrorDefaultDescription { get; }

        Task<bool> IsSatisfiedByAsync(T entity);
    }
}



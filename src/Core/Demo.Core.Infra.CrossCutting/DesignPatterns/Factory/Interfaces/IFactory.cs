using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces
{
    public interface IFactory<TReturn>
    {
        Task<TReturn> CreateAsync();
    }
}

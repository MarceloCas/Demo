namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces
{
    public interface IFactoryWithParameters<TReturn, TInput>
        : IFactory<TReturn>
    {
        TReturn Create(TInput input);
    }
}

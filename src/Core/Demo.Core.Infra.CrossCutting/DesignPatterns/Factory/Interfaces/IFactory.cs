namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces
{
    public interface IFactory<TReturn>
    {
        TReturn Create();
    }
}

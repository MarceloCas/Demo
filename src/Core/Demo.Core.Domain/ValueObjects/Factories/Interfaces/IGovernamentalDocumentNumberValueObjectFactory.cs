using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;

namespace Demo.Core.Domain.ValueObjects.Factories.Interfaces
{
    public interface IGovernamentalDocumentNumberValueObjectFactory
        : IFactoryWithParameters<GovernamentalDocumentNumberValueObject, string>
    {
    }
}

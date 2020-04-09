using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;

namespace Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.Factories.Interfaces
{
    public interface IGovernamentalDocumentNumberValueObjectFactory
        : IFactoryWithParameters<GovernamentalDocumentNumberValueObject, string>
    {
    }
}

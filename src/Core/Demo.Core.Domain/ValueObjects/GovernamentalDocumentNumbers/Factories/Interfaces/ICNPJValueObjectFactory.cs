using Demo.Core.Domain.ValueObjects.CNPJs;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;

namespace Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.Factories.Interfaces
{
    public interface ICNPJValueObjectFactory
        : IFactoryWithParameters<CNPJValueObject, string>
    {
    }
}

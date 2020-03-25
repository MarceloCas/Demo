using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.ValueObjects.Factories.Interfaces
{
    public interface IGovernamentalDocumentNumberValueObjectFactory
        : IFactoryWithParameters<GovernamentalDocumentNumberValueObject, string>
    {
    }
}

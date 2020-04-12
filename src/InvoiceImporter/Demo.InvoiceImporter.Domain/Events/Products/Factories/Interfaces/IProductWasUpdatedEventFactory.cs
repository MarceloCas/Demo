using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.Events.Products.Factories.Interfaces
{
    public interface IProductWasUpdatedEventFactory
        : IFactoryWithParameters<ProductWasUpdatedEvent, Product>
    {

    }
}

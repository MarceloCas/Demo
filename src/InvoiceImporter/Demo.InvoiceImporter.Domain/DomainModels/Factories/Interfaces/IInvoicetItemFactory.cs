using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces
{
    public interface IInvoicetItemFactory
        : IFactory<InvoiceItem>
    {
    }
}

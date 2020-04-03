using Demo.Core.Domain.Queries.DomainModelsBase;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.Handlers.Queries.Customers.Interfaces
{
    public interface IGetDomainModelByIdQueryHandler
        : IQueryHandler<GetDomainModelByIdQuery<Customer>>
    {
    }
}

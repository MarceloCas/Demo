using Demo.Core.Domain.DomainModels.Base.Interfaces;
using Demo.Core.Domain.DomainServices.Base.Interfaces;
using Demo.Core.Domain.Repositories.Base.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainServices.Base
{
    public class DomainServiceBase<TAuditableDomainModel>
        : Core.Domain.DomainServices.Base.DomainServiceBase<TAuditableDomainModel>
        where TAuditableDomainModel : IAuditableDomainModel
    {
        public DomainServiceBase(
            IBus bus,
            IFactory<TAuditableDomainModel> factory)
            : base(bus, factory)
        {

        }
    }
}

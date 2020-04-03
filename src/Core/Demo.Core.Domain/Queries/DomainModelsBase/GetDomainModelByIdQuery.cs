using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.Queries.DomainModelsBase
{
    public class GetDomainModelByIdQuery<TDomainModel>
        : Query<TDomainModel>
        where TDomainModel : DomainModelBase
    {
        // Properties
        public Guid DomainModelId { get; protected set; }

        // Public methods
        public void SetDomainModelId(Guid id)
        {
            DomainModelId = id;
        }
    }
}

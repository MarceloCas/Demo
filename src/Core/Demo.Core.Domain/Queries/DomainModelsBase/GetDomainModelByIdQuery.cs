using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;

namespace Demo.Core.Domain.Queries.DomainModelsBase
{
    public class GetDomainModelByIdQuery<TDomainModel>
        : Query<IEnumerable<TDomainModel>>
        where TDomainModel : DomainModelBase
    {
        // Properties
        public Guid DomainModelId { get; protected set; }

        // Public methods
        public GetDomainModelByIdQuery<TDomainModel> SetDomainModelId(Guid id)
        {
            DomainModelId = id;

            return this;
        }
    }
}

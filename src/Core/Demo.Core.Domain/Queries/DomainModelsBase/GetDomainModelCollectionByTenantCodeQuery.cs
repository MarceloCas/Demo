using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.Queries.DomainModelsBase
{
    public class GetDomainModelCollectionByTenantCodeQuery<TDomainModel>
        : Query<IEnumerable<TDomainModel>>
        where TDomainModel : DomainModelBase
    {

    }
}

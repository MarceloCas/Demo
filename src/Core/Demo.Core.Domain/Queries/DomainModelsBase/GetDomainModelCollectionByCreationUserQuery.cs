using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.Queries.DomainModelsBase
{
    public class GetDomainModelCollectionByCreationUserQuery<TDomainModel>
        : Query<IEnumerable<TDomainModel>>
        where TDomainModel : DomainModelBase
    {
        // Properties
        public string CreationUser { get; protected set; }

        // Public Methods
        public GetDomainModelCollectionByCreationUserQuery<TDomainModel> SetCreationUser(string creationUser)
        {
            CreationUser = creationUser;

            return this;
        }
    }
}

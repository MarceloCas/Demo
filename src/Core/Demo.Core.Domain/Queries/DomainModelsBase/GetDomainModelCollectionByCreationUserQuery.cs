using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System.Collections.Generic;

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

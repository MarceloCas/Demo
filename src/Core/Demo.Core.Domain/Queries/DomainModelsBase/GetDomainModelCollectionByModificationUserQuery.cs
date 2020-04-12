using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.Queries.DomainModelsBase
{
    public class GetDomainModelCollectionByModificationUserQuery<TDomainModel>
        : Query<IEnumerable<TDomainModel>>
        where TDomainModel : DomainModelBase
    {
        // Properties
        public string ModificationUser { get; protected set; }

        // Public Methods
        public GetDomainModelCollectionByModificationUserQuery<TDomainModel> SetModificationUser(string modificationUser)
        {
            ModificationUser = modificationUser;

            return this;
        }
    }
}

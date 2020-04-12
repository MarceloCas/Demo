using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.Queries.DomainModelsBase
{
    public class GetDomainModelCollectionByModificationDateQuery<TDomainModel>
        : Query<IEnumerable<TDomainModel>>
        where TDomainModel : DomainModelBase
    {
        // Properties
        public DateTime? StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }

        // Public Methods
        public GetDomainModelCollectionByModificationDateQuery<TDomainModel> SetDateInterval(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;

            return this;
        }
    }
}

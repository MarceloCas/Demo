﻿using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;

namespace Demo.Core.Domain.Queries.DomainModelsBase
{
    public class GetDomainModelCollectionByCreationDateQuery<TDomainModel>
        : Query<IEnumerable<TDomainModel>>
        where TDomainModel : DomainModelBase
    {
        // Properties
        public DateTime? StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }

        // Public Methods
        public GetDomainModelCollectionByCreationDateQuery<TDomainModel> SetDateInterval(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;

            return this;
        }
    }
}

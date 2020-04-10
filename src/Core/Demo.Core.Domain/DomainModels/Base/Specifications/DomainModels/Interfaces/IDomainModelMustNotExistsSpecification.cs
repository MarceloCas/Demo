using Demo.Core.Domain.Queries.DomainModelsBase;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces
{
    public interface IDomainModelMustNotExistsSpecification
        : ISpecification<DomainModelBase>
    {
        QueryBase GetDomainModelByIdQuery { get; }

        void SetGetDomainModelByIdQuery<TDomainModel>(GetDomainModelByIdQuery<TDomainModel> query)
            where TDomainModel : DomainModelBase;
    }
}

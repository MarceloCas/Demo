using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.Queries.DomainModelsBase;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels
{
    public class DomainModelMustNotExistsSpecification
        : SpecificationBase<DomainModelBase>,
        IDomainModelMustNotExistsSpecification
    {
        // Properties
        public QueryBase GetDomainModelByIdQuery { get; private set; }

        // Constructors
        public DomainModelMustNotExistsSpecification(
            IBus bus,
            IGlobalizationConfig globalizationConfig
            )
            : base(bus, globalizationConfig)
        {

        }

        // Public methods
        public void SetGetDomainModelByIdQuery<TDomainModel>(
            GetDomainModelByIdQuery<TDomainModel> query
            ) where TDomainModel : DomainModelBase
        {
            GetDomainModelByIdQuery = query;
        }

        public async override Task<bool> IsSatisfiedByAsync(DomainModelBase entity)
        {
            await Bus.SendQueryAsync(GetDomainModelByIdQuery);

            return (GetDomainModelByIdQuery?.Id ?? Guid.Empty) == Guid.Empty;
        }

    }
}

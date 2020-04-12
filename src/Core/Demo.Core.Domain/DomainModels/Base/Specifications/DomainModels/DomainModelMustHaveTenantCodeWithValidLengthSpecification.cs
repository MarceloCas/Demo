using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.ExtensionMethods;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System.Threading.Tasks;

namespace Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels
{
    public class DomainModelMustHaveTenantCodeWithValidLengthSpecification
        : SpecificationBase<DomainModelBase>,
        IDomainModelMustHaveTenantCodeWithValidLengthSpecification
    {
        public DomainModelMustHaveTenantCodeWithValidLengthSpecification(
            IBus bus,
            IGlobalizationConfig globalizationConfig) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(DomainModelBase entity)
        {
            if (string.IsNullOrWhiteSpace(entity?.TenantCode))
                return await Task.FromResult(true);

            return await Task.FromResult(entity.TenantCode.LengthIsBetween(1, 150));
        }
    }
}

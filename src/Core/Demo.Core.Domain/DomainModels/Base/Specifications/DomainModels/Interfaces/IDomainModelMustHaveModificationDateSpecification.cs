using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;

namespace Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces
{
    public interface IDomainModelMustHaveModificationDateSpecification
        : ISpecification<DomainModelBase>
    {
    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces
{
    public interface IDomainModelMustHaveCreationDateSpecification
        : ISpecification<DomainModelBase>
    {
    }
}

using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.DomainModels.Base.Validations.Base
{
    public abstract class DomainModelValidationBase<TDomainModel>
        : Validator<TDomainModel>
        where TDomainModel : DomainModelBase
    {
        private readonly IDomainModelMustHaveIdSpecification _domainModelMustHaveIdSpecification;

        protected DomainModelValidationBase(
            IDomainModelMustHaveIdSpecification domainModelMustHaveIdSpecification
            )
        {
            _domainModelMustHaveIdSpecification = domainModelMustHaveIdSpecification;
        }

        protected void AddMustHaveIdSpecification()
        {
            var code = $"{typeof(TDomainModel).Name}MustHaveIdSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustHaveIdSpecification, code, code));
        }
    }
}

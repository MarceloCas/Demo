using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.Queries.DomainModelsBase;
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
        private readonly IDomainModelMustExistsSpecification _domainModelMustExistsSpecification;

        protected DomainModelValidationBase(
            IDomainModelMustHaveIdSpecification domainModelMustHaveIdSpecification,
            IDomainModelMustExistsSpecification domainModelMustExistsSpecification
            )
        {
            _domainModelMustHaveIdSpecification = domainModelMustHaveIdSpecification;
            _domainModelMustExistsSpecification = domainModelMustExistsSpecification;
        }

        protected void AddMustHaveIdSpecification()
        {
            var code = $"{typeof(TDomainModel).Name}MustHaveIdSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustHaveIdSpecification, code, code));
        }
        protected void AddMustExistsSpecification()
        {
            _domainModelMustExistsSpecification.SetGetDomainModelByIdQuery(new GetDomainModelByIdQuery<TDomainModel>());

            var code = $"{typeof(TDomainModel).Name}MustExistsSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustExistsSpecification, code, code));
        }
    }
}

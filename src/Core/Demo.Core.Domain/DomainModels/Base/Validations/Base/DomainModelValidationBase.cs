using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Domain.Queries.DomainModelsBase;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;

namespace Demo.Core.Domain.DomainModels.Base.Validations.Base
{
    public abstract class DomainModelValidationBase<TDomainModel>
        : Validator<TDomainModel>
        where TDomainModel : DomainModelBase
    {
        private readonly IDomainModelMustExistsSpecification _domainModelMustExistsSpecification;
        private readonly IDomainModelMustHaveCreationDateSpecification _domainModelMustHaveCreationDateSpecification;
        private readonly IDomainModelMustHaveCreationUserSpecification _domainModelMustHaveCreationUserSpecification;
        private readonly IDomainModelMustHaveIdSpecification _domainModelMustHaveIdSpecification;
        private readonly IDomainModelMustHaveModificationDateGreaterThanCreationDateSpecification _domainModelMustHaveModificationDateGreaterThanCreationDateSpecification;
        private readonly IDomainModelMustHaveModificationDateSpecification _domainModelMustHaveModificationDateSpecification;
        private readonly IDomainModelMustHaveModificationUserSpecification _domainModelMustHaveModificationUserSpecification;
        private readonly IDomainModelMustHaveTenantCodeSpecification _domainModelMustHaveTenantCodeSpecification;
        private readonly IDomainModelMustHaveTenantCodeWithValidLengthSpecification _domainModelMustHaveTenantCodeWithValidLengthSpecification;
        private readonly IDomainModelMustNotExistsSpecification _domainModelMustNotExistsSpecification;

        protected DomainModelValidationBase(
            IDomainModelMustExistsSpecification domainModelMustExistsSpecification,
            IDomainModelMustHaveCreationDateSpecification domainModelMustHaveCreationDateSpecification,
            IDomainModelMustHaveCreationUserSpecification domainModelMustHaveCreationUserSpecification,
            IDomainModelMustHaveIdSpecification domainModelMustHaveIdSpecification,
            IDomainModelMustHaveModificationDateGreaterThanCreationDateSpecification domainModelMustHaveModificationDateGreaterThanCreationDateSpecification,
            IDomainModelMustHaveModificationDateSpecification domainModelMustHaveModificationDateSpecification,
            IDomainModelMustHaveModificationUserSpecification domainModelMustHaveModificationUserSpecification,
            IDomainModelMustHaveTenantCodeSpecification domainModelMustHaveTenantCodeSpecification,
            IDomainModelMustHaveTenantCodeWithValidLengthSpecification domainModelMustHaveTenantCodeWithValidLengthSpecification,
            IDomainModelMustNotExistsSpecification domainModelMustNotExistsSpecification
            )
        {
            _domainModelMustExistsSpecification = domainModelMustExistsSpecification;
            _domainModelMustHaveCreationDateSpecification = domainModelMustHaveCreationDateSpecification;
            _domainModelMustHaveCreationUserSpecification = domainModelMustHaveCreationUserSpecification;
            _domainModelMustHaveIdSpecification = domainModelMustHaveIdSpecification;
            _domainModelMustHaveModificationDateGreaterThanCreationDateSpecification = domainModelMustHaveModificationDateGreaterThanCreationDateSpecification;
            _domainModelMustHaveModificationDateSpecification = domainModelMustHaveModificationDateSpecification;
            _domainModelMustHaveModificationUserSpecification = domainModelMustHaveModificationUserSpecification;
            _domainModelMustHaveTenantCodeSpecification = domainModelMustHaveTenantCodeSpecification;
            _domainModelMustHaveTenantCodeWithValidLengthSpecification = domainModelMustHaveTenantCodeWithValidLengthSpecification;
            _domainModelMustNotExistsSpecification = domainModelMustNotExistsSpecification;
        }

        protected void AddMustExistsSpecification()
        {
            _domainModelMustExistsSpecification.SetGetDomainModelByIdQuery(new GetDomainModelByIdQuery<TDomainModel>());

            var code = $"{typeof(TDomainModel).Name}MustExistsSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustExistsSpecification, code, code));
        }
        protected void AddMustHaveCreationDateSpecification()
        {
            var code = $"{typeof(TDomainModel).Name}MustHaveCreationDateSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustHaveCreationDateSpecification, code, code));
        }
        protected void AddMustHaveCreationUserSpecification()
        {
            var code = $"{typeof(TDomainModel).Name}MustHaveCreationUserSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustHaveCreationUserSpecification, code, code));
        }
        protected void AddMustHaveIdSpecification()
        {
            var code = $"{typeof(TDomainModel).Name}MustHaveIdSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustHaveIdSpecification, code, code));
        }
        protected void AddMustHaveModificationDateGreaterThanCreationDateSpecification()
        {
            var code = $"{typeof(TDomainModel).Name}MustHaveModificationDateGreaterThanCreationDateSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustHaveModificationDateGreaterThanCreationDateSpecification, code, code));
        }
        protected void AddMustHaveModificationDateSpecification()
        {
            var code = $"{typeof(TDomainModel).Name}MustHaveModificationDateSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustHaveModificationDateSpecification, code, code));
        }
        protected void AddMustHaveModificationUserSpecification()
        {
            var code = $"{typeof(TDomainModel).Name}MustHaveModificationUserSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustHaveModificationUserSpecification, code, code));
        }
        protected void AddMustHaveTenantCodeSpecification()
        {
            var code = $"{typeof(TDomainModel).Name}MustHaveTenantCodeSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustHaveTenantCodeSpecification, code, code));
        }
        protected void AddMustHaveTenantCodeWithValidLengthSpecification()
        {
            var code = $"{typeof(TDomainModel).Name}MustHaveTenantCodeWithValidLengthSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustHaveTenantCodeWithValidLengthSpecification, code, code));
        }
        protected void AddMustNotExistsSpecification()
        {
            _domainModelMustNotExistsSpecification.SetGetDomainModelByIdQuery(new GetDomainModelByIdQuery<TDomainModel>());

            var code = $"{typeof(TDomainModel).Name}MustNotExistsSpecification";

            Add(code, new Rule<TDomainModel>(_domainModelMustNotExistsSpecification, code, code));
        }
    }
}

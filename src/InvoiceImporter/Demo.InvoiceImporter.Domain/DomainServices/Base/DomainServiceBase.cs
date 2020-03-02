using Demo.Core.Domain.DomainModels.Base.Interfaces;
using Demo.Core.Domain.DomainServices.Base.Interfaces;
using Demo.Core.Domain.Repositories.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainServices.Base
{
    public class DomainServiceBase<TAuditableDomainModel>
        : Core.Domain.DomainServices.Base.DomainServiceBase<TAuditableDomainModel>
        where TAuditableDomainModel : IAuditableDomainModel
    {
        private readonly IAuditableRepository<TAuditableDomainModel> _repository;

        protected IAuditableRepository<TAuditableDomainModel> Repository
        {
            get
            {
                return _repository;
            }
        }

        public DomainServiceBase(IAuditableRepository<TAuditableDomainModel> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}

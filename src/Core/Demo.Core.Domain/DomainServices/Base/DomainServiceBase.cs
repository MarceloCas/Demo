using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Base.Interfaces;
using Demo.Core.Domain.DomainServices.Base.Interfaces;
using Demo.Core.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.DomainServices.Base
{
    public abstract class DomainServiceBase<TDomainModel>
        : IDomainService<TDomainModel>
        where TDomainModel : IDomainModel
    {
        private readonly IRepository<TDomainModel> _repository;

        protected IRepository<TDomainModel> Repository
        {
            get
            {
                return _repository;
            }
        }

        public DomainServiceBase(IRepository<TDomainModel> repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

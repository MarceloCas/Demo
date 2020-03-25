using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Base.Interfaces;
using Demo.Core.Domain.DomainServices.Base.Interfaces;
using Demo.Core.Domain.Repositories.Base;
using Demo.Core.Domain.Repositories.Base.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
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
        private readonly IFactory<TDomainModel> _factory;

        protected IRepository<TDomainModel> Repository
        {
            get
            {
                return _repository;
            }
        }
        protected IFactory<TDomainModel> Factory
        {
            get
            {
                return _factory;
            }
        }

        public DomainServiceBase(
            IRepository<TDomainModel> repository,
            IFactory<TDomainModel> factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

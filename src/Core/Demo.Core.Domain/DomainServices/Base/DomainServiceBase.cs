using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Base.Interfaces;
using Demo.Core.Domain.DomainServices.Base.Interfaces;
using Demo.Core.Domain.Repositories.Base;
using Demo.Core.Domain.Repositories.Base.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
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
        private readonly IBus _bus;
        private readonly IFactory<TDomainModel> _factory;

        protected IBus Bus
        {
            get
            {
                return _bus;
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
            IBus repository,
            IFactory<TDomainModel> factory)
        {
            _bus = repository;
            _factory = factory;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

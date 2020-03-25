using Demo.Core.Domain.DomainModels.Base.Interfaces;
using Demo.Core.Domain.Repositories.Base.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;

namespace Demo.InvoiceImporter.Domain.DomainServices.Base
{
    public class DomainServiceBase<TAuditableDomainModel>
        : Core.Domain.DomainServices.Base.DomainServiceBase<TAuditableDomainModel>
        where TAuditableDomainModel : IAuditableDomainModel
    {
        public DomainServiceBase(
            IAuditableRepository<TAuditableDomainModel> repository,
            IFactory<TAuditableDomainModel> factory)
            : base(repository, factory)
        {

        }
    }
}

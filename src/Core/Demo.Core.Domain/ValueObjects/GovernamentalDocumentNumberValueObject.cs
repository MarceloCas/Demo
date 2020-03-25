using Demo.Core.Domain.ValueObjects.Base;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;

namespace Demo.Core.Domain.ValueObjects
{
    public class GovernamentalDocumentNumberValueObject
        : ValueObjectBase
    {
        public string DocumentNumber { get; protected set; }

        public virtual GovernamentalDocumentNumberValueObject SetDocumentNumber(string documentNumber)
        {
            DocumentNumber = documentNumber;
            return this;
        }

        #region Factories
        public class GovernamentalDocumentNumberValueObjectFactory
            : FactoryBase<GovernamentalDocumentNumberValueObject>,
            IGovernamentalDocumentNumberValueObjectFactory
        {
            public override GovernamentalDocumentNumberValueObject Create()
            {
                return new GovernamentalDocumentNumberValueObject();
            }
            public GovernamentalDocumentNumberValueObject Create(string documentNumber)
            {
                return Create()
                    .SetDocumentNumber(documentNumber);
            }
        }
        #endregion
    }
}

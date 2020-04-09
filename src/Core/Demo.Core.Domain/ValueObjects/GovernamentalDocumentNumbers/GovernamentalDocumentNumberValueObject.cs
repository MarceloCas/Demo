using Demo.Core.Domain.ValueObjects.Base;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System.Threading.Tasks;

namespace Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers
{
    public class GovernamentalDocumentNumberValueObject
        : ValueObjectBase
    {
        public string DocumentNumber { get; protected set; }

        protected GovernamentalDocumentNumberValueObject() { }

        public virtual TDocumentNumber SetDocumentNumber<TDocumentNumber>(string documentNumber)
            where TDocumentNumber : GovernamentalDocumentNumberValueObject
        {
            DocumentNumber = documentNumber;
            return (TDocumentNumber) this;
        }

        #region Factories
        public class GovernamentalDocumentNumberValueObjectFactory
            : FactoryBase<GovernamentalDocumentNumberValueObject>,
            IGovernamentalDocumentNumberValueObjectFactory
        {
            public GovernamentalDocumentNumberValueObjectFactory(IGlobalizationConfig globalizationConfig) 
                : base(globalizationConfig)
            {
            }

            public override async Task<GovernamentalDocumentNumberValueObject> CreateAsync()
            {
                return await Task.FromResult(new GovernamentalDocumentNumberValueObject());
            }
            public async Task<GovernamentalDocumentNumberValueObject> CreateAsync(string documentNumber)
            {
                return (await CreateAsync())
                    .SetDocumentNumber<GovernamentalDocumentNumberValueObject>(documentNumber);
            }
        }
        #endregion
    }
}

using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Domain.ValueObjects.CNPJs
{
    public class CNPJValueObject
        : GovernamentalDocumentNumberValueObject
    {
        protected CNPJValueObject() { }

        #region Factories
        public class CNPJValueObjectFactory
            : FactoryBase<CNPJValueObject>,
            ICNPJValueObjectFactory
        {
            public CNPJValueObjectFactory(IGlobalizationConfig globalizationConfig)
                : base(globalizationConfig)
            {
            }

            public override async Task<CNPJValueObject> CreateAsync()
            {
                return await Task.FromResult(new CNPJValueObject());
            }
            public async Task<CNPJValueObject> CreateAsync(string documentNumber)
            {
                return (await CreateAsync())
                    .SetDocumentNumber<CNPJValueObject>(documentNumber);
            }
        }
        #endregion
    }
}

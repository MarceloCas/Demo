using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

            public override CNPJValueObject Create()
            {
                return new CNPJValueObject();
            }
            public CNPJValueObject Create(string documentNumber)
            {
                return Create()
                    .SetDocumentNumber<CNPJValueObject>(documentNumber);
            }
        }
        #endregion
    }
}

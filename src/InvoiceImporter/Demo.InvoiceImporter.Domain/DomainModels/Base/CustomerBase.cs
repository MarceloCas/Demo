using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.ValueObjects.GovernamentalDocumentNumbers;
using Demo.InvoiceImporter.Domain.DomainModels.Interfaces;
using System;

namespace Demo.InvoiceImporter.Domain.DomainModels.Base
{
    public abstract class CustomerBase
        : DomainModelBase,
        ICustomer
    {
        private readonly GovernamentalDocumentNumberValueObject _governamentalDocumentNumberValueObject;


        // Properties
        public string Name { get; protected set; }
        public string GovernamentalDocumentNumber
        {
            get { return _governamentalDocumentNumberValueObject.DocumentNumber; }
            set { _governamentalDocumentNumberValueObject.SetDocumentNumber<GovernamentalDocumentNumberValueObject>(value); }
        }

        // Constructors
        protected CustomerBase(GovernamentalDocumentNumberValueObject governamentalDocumentNumberValueObject) 
        {
            _governamentalDocumentNumberValueObject = governamentalDocumentNumberValueObject;
        }

        // Private Methods
        protected virtual CustomerBase GenerateNewId()
        {
            Id = Guid.NewGuid();
            return this;
        }
        protected virtual CustomerBase SetGovernamentalDocumentNumber(string documentNumber)
        {
            GovernamentalDocumentNumber = documentNumber;
            return this;
        }

        // Public Methods
        public virtual TCustomer ImportCustomer<TCustomer>(string tenantCode, string name, string governamentalNumber, string creationUser)
            where TCustomer : CustomerBase
        {
            GenerateNewId();
            SetGovernamentalDocumentNumber(governamentalNumber);
            SetCreationInfo(tenantCode, creationUser);

            return (TCustomer)this;
        }
    }
}

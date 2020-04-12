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
        // Attributes
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
        protected virtual CustomerBase SetName(string name)
        {
            Name = name;

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
            SetTenantCode(tenantCode);
            SetName(name);
            SetGovernamentalDocumentNumber(governamentalNumber);
            SetCreationInfo(creationUser);

            return (TCustomer)this;
        }
    }
}

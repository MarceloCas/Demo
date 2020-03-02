using Demo.Core.Domain.DomainModels.Base;
using Demo.Core.Domain.DomainModels.Interfaces;
using Demo.Core.Domain.ValueObjects;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using Demo.InvoiceImporter.Domain.DomainModels.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Demo.InvoiceImporter.Domain.DomainModels.Customer;

namespace Demo.InvoiceImporter.Domain.DomainModels
{
    public class Customer
        : DomainModelBase,
        ICustomer
    {
        // Attributes
        private GovernamentalDocumentNumberValueObject _governamentalDocumentoNumber;

        // Properties
        public string Name { get; protected set; }
        public string GovernamentalDocumentNumber 
        {
            get
            {
                return _governamentalDocumentoNumber.DocumentNumber;
            }
            protected set
            {
                _governamentalDocumentoNumber.SetDocumentNumber(value);
            }
        }

        // Constructors
        protected Customer() 
        {
            _governamentalDocumentoNumber = new GovernamentalDocumentNumberValueObject();
        }

        // Private Methods
        private Customer GenerateNewId()
        {
            Id = Guid.NewGuid();
            return this;
        }
        private Customer SetGovernamentalDocumentNumber(string documentNumber)
        {
            GovernamentalDocumentNumber = documentNumber;
            return this;
        }

        // Public Methods
        public Customer ImportCustomer(string tenantCode, string name, string governamentalNumber, string creationUser)
        {
            GenerateNewId();
            SetGovernamentalDocumentNumber(governamentalNumber);
            SetCreationInfo(tenantCode, creationUser);

            return this;
        }

        #region Factories
        public class CustomerFactory
            : DomainModelBaseFactory<Customer>,
            ICustomerFactory
        {
            public CustomerFactory(ITenantInfoValueObjectFactory tenantInfoValueObjectFactory) 
                : base(tenantInfoValueObjectFactory)
            {
            }

            public override Customer Create()
            {
                return RegisterBaseTypes(new Customer());
            }
        }
        #endregion
    }
}

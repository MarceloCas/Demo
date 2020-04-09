using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using System;
using System.Collections.Generic;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers
{
    public abstract class DomainNotificationHandlerBase<TDomainNotification>
        : IDomainNotificationHandler<TDomainNotification>
        where TDomainNotification : DomainNotification
    {
        public DomainNotificationHandler<TDomainNotification> DomainNotificationHandler { get; protected set; }
        public ICollection<TDomainNotification> DomainNotificationsCollection { get; protected set; }

        // Constructors
        protected DomainNotificationHandlerBase()
        {
            DomainNotificationsCollection = new List<TDomainNotification>();
            DomainNotificationHandler = GetDomainNotificationHandler();
        }

        // Public Methods
        public abstract void AddDomainNotification(DomainNotificationTypeEnum type, string code, string defaultDescription);
        public abstract void AddDomainNotification(TDomainNotification domainNotification);
        public abstract void AddDomainNotificationFromValidationResult(ValidationResult validationResult);

        // Abstract Methods
        protected abstract DomainNotificationHandler<TDomainNotification> GetDomainNotificationHandler();

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

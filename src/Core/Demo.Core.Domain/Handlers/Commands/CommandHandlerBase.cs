using Demo.Core.Domain.ValueObjects;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using System;

namespace Demo.Core.Domain.Handlers.Commands
{
    public abstract class CommandHandlerBase<TCommand>
        : ICommandHandler<TCommand>
        where TCommand : Command
    {

        // Properties
        public CommandHandler<TCommand> CommandHandler { get; protected set; }
        public TenantInfoValueObject TenantInfoValueObject { get; }
        public IInMemoryDefaultDomainNotificationHandler InMemoryDefaultDomainNotificationHandler { get; }

        // Constructors
        protected CommandHandlerBase(
            ITenantInfoValueObjectFactory tenantInfoValueObjectFactory,
            IInMemoryDefaultDomainNotificationHandler inMemoryDefaultDomainNotificationHandler
            )
        {
            TenantInfoValueObject = tenantInfoValueObjectFactory.CreateAsync().GetAwaiter().GetResult();
            InMemoryDefaultDomainNotificationHandler = inMemoryDefaultDomainNotificationHandler;
            CommandHandler = GetCommandHandler();
        }

        // Abstract Methods
        protected abstract CommandHandler<TCommand> GetCommandHandler();

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

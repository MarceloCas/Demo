using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;
using Demo.Core.Infra.CrossCutting.IoC.Models;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus
{
    public class InMemoryBus
        : IBus
    {
        // Attributes
        private readonly IServiceProvider _serviceProvider;
        private readonly IHandlerRegistrationManager _handlerRegistrationManager;
        private readonly TypeRegistration[] _typeRegistrationCollection;

        // Constructors
        public InMemoryBus(
            IServiceProvider serviceProvider,
            TypeRegistration[] typeRegistrationCollection)
        {
            _serviceProvider = serviceProvider;
            _handlerRegistrationManager = (IHandlerRegistrationManager)_serviceProvider.GetService(typeof(IHandlerRegistrationManager));
            _typeRegistrationCollection = typeRegistrationCollection;
        }

        // Public Methods
        public async Task<bool> SendDomainNotificationAsync<TDomainNotification>(TDomainNotification domainNotification) where TDomainNotification : DomainNotification
        {
            var processResult = true;
            var domainNotificationType = domainNotification.GetType();

            // 1º step - Get all registration for this domainNotification ordered by Order property
            var handlerRegistrationsCollection = _handlerRegistrationManager?.DomainNotificationHandlerRegistrationsCollection
                .Where(registration => registration.MessageType == domainNotificationType)
                .OrderBy(q => q.Order);

            // 2º step - Handle each handlerRegistration
            foreach (var handlerRegistration in handlerRegistrationsCollection)
            {
                // 3º step - Get a instance of HandlerType and handle domainNotification
                var handler = _serviceProvider.GetService(handlerRegistration.HandlerType);
                var domainNotificationHanlerProperty = handler.GetType().GetProperty(nameof(IDomainNotificationHandler<TDomainNotification>.DomainNotificationHandler));
                var domainNotificationHandlerDelegate = domainNotificationHanlerProperty.GetValue(handler);
                var domainNotificationHandlerDelegateInvokeMethodInfo = domainNotificationHandlerDelegate.GetType().GetMethod(nameof(DomainNotificationHandler<TDomainNotification>.Invoke));

                // 4º step - Call handler
                if (handlerRegistration.IsAsync)
                {
                    _ = Task.Run(() => {
                        var handlerReturnTask = (Task<bool>)domainNotificationHandlerDelegateInvokeMethodInfo.Invoke(domainNotificationHandlerDelegate, new[] { domainNotification });
                        handlerReturnTask.Wait();
                    });
                }
                else
                {
                    var handlerReturnTask = (Task<bool>)domainNotificationHandlerDelegateInvokeMethodInfo.Invoke(domainNotificationHandlerDelegate, new[] { domainNotification });
                    handlerReturnTask.Wait();

                    processResult = handlerReturnTask.Result;

                    if (processResult && handlerRegistration.StopOnError)
                        break;
                }
            }

            return await Task.FromResult(processResult);
        }
        public async Task<bool> SendCommandAsync<TCommand>(TCommand command) where TCommand : Command
        {
            var processResult = true;
            var commandType = command.GetType();

            // 1º step - Get all registration for this command ordered by Order property
            var handlerRegistrationsCollection = _handlerRegistrationManager?.CommandHandlerRegistrationsCollection
                .Where(registration => registration.MessageType == commandType)
                .OrderBy(q => q.Order);

            // 2º step - Handle each handlerRegistration
            foreach (var handlerRegistration in handlerRegistrationsCollection)
            {
                // 3º step - Get a instance of HandlerType and handle command
                var handler = _serviceProvider.GetService(handlerRegistration.HandlerType);
                var commandHanlerProperty = handler.GetType().GetProperty(nameof(ICommandHandler<TCommand>.CommandHandler));
                var commandHandlerDelegate = commandHanlerProperty.GetValue(handler);
                var commandHandlerDelegateInvokeMethodInfo = commandHandlerDelegate.GetType().GetMethod(nameof(CommandHandler<TCommand>.Invoke));

                // 4º step - Call handler
                if (handlerRegistration.IsAsync)
                {
                    _ = Task.Run(() => {
                        var handlerReturnTask = (Task<bool>)commandHandlerDelegateInvokeMethodInfo.Invoke(commandHandlerDelegate, new[] { command });
                        handlerReturnTask.Wait();
                    });
                }
                else
                {
                    var handlerReturnTask = (Task<bool>)commandHandlerDelegateInvokeMethodInfo.Invoke(commandHandlerDelegate, new[] { command });
                    handlerReturnTask.Wait();

                    processResult = handlerReturnTask.Result;

                    if (processResult && handlerRegistration.StopOnError)
                        break;
                }
            }

            return await Task.FromResult(processResult);
        }
        public async Task<TQuery> SendQueryAsync<TQuery>(TQuery query) where TQuery : QueryBase
        {
            var processResult = query;
            var queryType = query.GetType();

            // 1º step - Get all registration for this query ordered by Order property
            var handlerRegistrationsCollection = _handlerRegistrationManager?.QueryHandlerRegistrationsCollection
                .Where(registration => registration.MessageType == queryType)
                .OrderBy(q => q.Order);

            // 2º step - Handle each handlerRegistration
            foreach (var handlerRegistration in handlerRegistrationsCollection)
            {
                // 3º step - Get a instance of HandlerType and handle query
                var handler = _serviceProvider.GetService(handlerRegistration.HandlerType);
                var queryHanlerProperty = handler.GetType().GetProperty(nameof(IQueryHandler<TQuery>.QueryHandler));
                var queryHandlerDelegate = queryHanlerProperty.GetValue(handler);
                var queryHandlerDelegateInvokeMethodInfo = queryHandlerDelegate.GetType().GetMethod(nameof(QueryHandler<TQuery>.Invoke));

                // 4º step - Call handler
                if (handlerRegistration.IsAsync)
                {
                    _ = Task.Run(() => {
                        var handlerReturnTask = (Task<bool>)queryHandlerDelegateInvokeMethodInfo.Invoke(queryHandlerDelegate, new[] { query });
                        handlerReturnTask.Wait();
                    });
                }
                else
                {
                    var handlerReturnTask = (Task<bool>)queryHandlerDelegateInvokeMethodInfo.Invoke(queryHandlerDelegate, new[] { query });
                    handlerReturnTask.Wait();

                    if (!handlerReturnTask.Result && handlerRegistration.StopOnError)
                        break;
                }
            }

            return await Task.FromResult(query);
        }

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

using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
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

            var registeredTypesCollection = new List<object>();

            var handlerRegistrationsCollection = _handlerRegistrationManager?.DomainNotificationHandlerRegistrationsCollection.Where(registration =>
                registration.MessageType == typeof(TDomainNotification))
                .ToList();
            if (handlerRegistrationsCollection?.Any() == false)
                return false;

            var registrationsCollection = new List<(HandlerRegistration handleRegistration, IDomainNotificationHandler<TDomainNotification> handle)>();

            foreach (var handlerRegistration in handlerRegistrationsCollection)
                if (handlerRegistration.HandlerType.GetInterfaces()
                    .Any(q => q == typeof(IDomainNotificationHandler<TDomainNotification>)))
                    foreach (var interfaceType in handlerRegistration.HandlerType.GetInterfaces())
                        foreach (IDomainNotificationHandler<TDomainNotification> domainNotificationHandler in _serviceProvider.GetServices(interfaceType)
                            .Where(q => q.GetType() == handlerRegistration.HandlerType))
                            if (!registrationsCollection.Any(q => q.handle.GetType() == domainNotificationHandler.GetType()))
                                registrationsCollection.Add(
                                    (handlerRegistration, domainNotificationHandler));

            foreach (var (handleRegistration, handle) in registrationsCollection.OrderBy(q => q.handleRegistration.Order))
            {
                if (handleRegistration.IsAsync)
                {
                    _ = Task.Run(async () =>
                    {
                        await handle.HandleAsync(domainNotification);
                    });
                }
                else
                {
                    var commandReturn = await handle.HandleAsync(domainNotification);
                    if (!commandReturn && handleRegistration.StopOnError)
                    {
                        processResult = false;
                        break;
                    }
                }
            }

            return await Task.FromResult(processResult);
        }
        public async Task<bool> SendCommandAsync<TCommand>(TCommand command) where TCommand : Command
        {
            var processResult = true;

            var registeredTypesCollection = new List<object>();

            var handlerRegistrationsCollection = _handlerRegistrationManager?.CommandHandlerRegistrationsCollection.Where(registration =>
                registration.MessageType == typeof(TCommand))
                .ToList();
            if (handlerRegistrationsCollection?.Any() == false)
                return false;

            var registrationsCollection = new List<(HandlerRegistration handleRegistration, ICommandHandler<TCommand> handle)>();

            foreach (var handlerRegistration in handlerRegistrationsCollection)
                if (handlerRegistration.HandlerType.GetInterfaces()
                    .Any(q => q == typeof(ICommandHandler<TCommand>)))
                    foreach (var interfaceType in handlerRegistration.HandlerType.GetInterfaces())
                        foreach (ICommandHandler<TCommand> commandHandler in _serviceProvider.GetServices(interfaceType)
                            .Where(q => q.GetType() == handlerRegistration.HandlerType))
                            if (!registrationsCollection.Any(q => q.handle.GetType() == commandHandler.GetType()))
                                registrationsCollection.Add(
                                    (handlerRegistration, commandHandler));

            foreach (var (handleRegistration, handle) in registrationsCollection.OrderBy(q => q.handleRegistration.Order))
            {
                if (handleRegistration.IsAsync)
                {
                    _ = Task.Run(async () =>
                    {
                        await handle.HandleAsync(command);
                    });
                }
                else
                {
                    var commandReturn = await handle.HandleAsync(command);
                    if (!commandReturn && handleRegistration.StopOnError)
                    {
                        processResult = false;
                        break;
                    }
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

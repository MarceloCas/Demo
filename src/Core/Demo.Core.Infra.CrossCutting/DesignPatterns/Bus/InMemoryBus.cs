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

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus
{
    public class InMemoryBus
        : IBus
    {
        // Attributes
        private readonly IServiceProvider _serviceProvider;
        private readonly IHandlerRegistrationManager _handlerRegistrationManager;

        // Constructors
        public InMemoryBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _handlerRegistrationManager = (IHandlerRegistrationManager)_serviceProvider.GetService(typeof(IHandlerRegistrationManager));

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

            var registeredTypesCollection = new List<object>();

            var handlerRegistrationsCollection = _handlerRegistrationManager?.QueryHandlerRegistrationsCollection.Where(registration =>
                registration.MessageType == queryType)
                .ToList();
            if (handlerRegistrationsCollection?.Any() == false)
                return processResult;

            var registrationsCollection = new List<(HandlerRegistration handleRegistration, IQueryHandler<TQuery> handle)>();

            foreach (var handlerRegistration in handlerRegistrationsCollection)
                if (handlerRegistration.HandlerType.GetInterfaces()
                    .Any(q => q.IsGenericType == true
                        && q.GetGenericTypeDefinition() == typeof(IQueryHandler<>)
                        && q.GetGenericArguments().Any(q1 => q1 == queryType)))
                    foreach (var interfaceType in handlerRegistration.HandlerType.GetInterfaces())
                        foreach (IQueryHandler<TQuery> queryHandler in _serviceProvider.GetServices(interfaceType)
                            .Where(q => q.GetType() == handlerRegistration.HandlerType))
                            if (!registrationsCollection.Any(q => q.handle.GetType() == queryHandler.GetType()))
                                registrationsCollection.Add(
                                    (handlerRegistration, queryHandler));

            foreach (var (handleRegistration, handle) in registrationsCollection.OrderBy(q => q.handleRegistration.Order))
            {
                if (handleRegistration.IsAsync)
                {
                    _ = Task.Run(async () =>
                    {
                        await handle.HandleAsync(query);
                    });
                }
                else
                {
                    var queryReturn = await handle.HandleAsync(query);
                    if (!queryReturn && handleRegistration.StopOnError)
                        break;
                }
            }
            return query;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

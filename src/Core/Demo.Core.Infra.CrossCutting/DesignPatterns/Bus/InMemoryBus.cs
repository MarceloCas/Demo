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
        private readonly IEnumerable<object> _domainNotificationHandlerRegisteredTypesCollection;

        // Constructors
        public InMemoryBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _handlerRegistrationManager = (IHandlerRegistrationManager)_serviceProvider.GetService(typeof(IHandlerRegistrationManager));

        }
        // Public Methods
        public async Task<bool> SendDomainNotification(DomainNotification domainNotification)
        {
            var registeredTypesCollection = _serviceProvider.GetServices(typeof(IDomainNotificationHandler));
            if (registeredTypesCollection?.Any() == false)
                return false;
            
            var handlerRegistrationsCollection = _handlerRegistrationManager.DomainNotificationHandlerRegistrationsCollection.Where(registration =>
                registration.MessageType == typeof(DomainNotification)).ToList();
            if (handlerRegistrationsCollection.Any() == false)
                return false;

            foreach (var registration in handlerRegistrationsCollection)
            {
                var handler = (IDomainNotificationHandler) registeredTypesCollection.FirstOrDefault(q => q.GetType() == registration.HandlerType);
                await handler.HandleAsync(domainNotification);
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> SendCommand<TCommand>(TCommand command) where TCommand : Command
        {
            var processResult = true;

            var registeredTypesCollection = new List<object>();

            var handlerRegistrationsCollection = _handlerRegistrationManager.CommandHandlerRegistrationsCollection.Where(registration =>
                registration.MessageType == typeof(TCommand))
                .ToList();
            if (handlerRegistrationsCollection.Any() == false)
                return false;

            var registrationsCollection = new List<(HandlerRegistration handleRegistration, ICommandHandler<TCommand> handle)>();
            
            // get handlers
            foreach (var handlerRegistration in handlerRegistrationsCollection)
                if (handlerRegistration.HandlerType.GetInterfaces()
                    .Any(q => q == typeof(ICommandHandler<TCommand>)))
                    foreach (var interfaceType in handlerRegistration.HandlerType.GetInterfaces())
                        foreach (ICommandHandler<TCommand> commandHandler in _serviceProvider.GetServices(interfaceType)
                            .Where(q => q.GetType() == handlerRegistration.HandlerType))
                            if(!registrationsCollection.Any(q => q.handle.GetType() == commandHandler.GetType()))
                                registrationsCollection.Add(
                                    (handlerRegistration, commandHandler));

            foreach (var (handleRegistration, handle) in registrationsCollection.OrderBy(q => q.handleRegistration.Order))
            {
                if (handleRegistration.IsAsync)
                {
                    _ = Task.Run(async () => {
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus
{
    public class HandlerRegistrationManager
        : IHandlerRegistrationManager
    {
        // Attributes
        private readonly List<HandlerRegistration> _domainNotificationHandleRegistrationCollection;
        private readonly List<HandlerRegistration> _commandHandlerRegistrationsCollection;
        private readonly List<HandlerRegistration> _queryHandlerRegistrationsCollection;
        private readonly List<HandlerRegistration> _eventHandlerRegistrationsCollection;

        // Properties
        public ICollection<HandlerRegistration> DomainNotificationHandlerRegistrationsCollection
        {
            get
            {
                return _domainNotificationHandleRegistrationCollection;
            }
        }
        public ICollection<HandlerRegistration> CommandHandlerRegistrationsCollection
        {
            get
            {
                return _commandHandlerRegistrationsCollection;
            }
        }
        public ICollection<HandlerRegistration> QueryHandlerRegistrationsCollection
        {
            get
            {
                return _queryHandlerRegistrationsCollection;
            }
        }
        public ICollection<HandlerRegistration> EventHandlerRegistrationsCollection
        {
            get
            {
                return _eventHandlerRegistrationsCollection;
            }
        }

        // Constructors
        public HandlerRegistrationManager()
        {
            _domainNotificationHandleRegistrationCollection = new List<HandlerRegistration>();
            _commandHandlerRegistrationsCollection = new List<HandlerRegistration>();
            _queryHandlerRegistrationsCollection = new List<HandlerRegistration>();
            _eventHandlerRegistrationsCollection = new List<HandlerRegistration>();
        }

        // Public Methods
        public void RegisterDomainNotificationHandler(Type domainNotificationType, Type handlerType, double order, bool isAsync)
        {
            var typeInterfaceCollection = domainNotificationType.GetInterfaces();
            var handlerInterfaceType = typeof(IDomainNotificationHandler<>);

            if (typeInterfaceCollection!.Any(q => q.GetGenericTypeDefinition() == handlerInterfaceType))
                throw new ArgumentOutOfRangeException($"The {nameof(domainNotificationType)} argument must implement {handlerInterfaceType.Name}<>");

            if (typeInterfaceCollection!.Any(q => 
                q.GetGenericTypeDefinition() == handlerInterfaceType
                && q.GetGenericArguments().Any(q1 => q1 == handlerType)
            ))
                throw new ArgumentOutOfRangeException($"The {nameof(handlerType)} must be a same type of generic argument for {nameof(domainNotificationType)} argument.");

            _domainNotificationHandleRegistrationCollection.Add(new HandlerRegistration
            {
                MessageType = domainNotificationType,
                HandlerType = handlerType,
                Order = order,
                StopOnError = false,
                IsAsync = isAsync
            });
        }
        public void RegisterCommandHandler(Type commandType, Type handlerType, double order, bool stopOnError, bool isAsync)
        {
            var typeInterfaceCollection = commandType.GetInterfaces();
            var handlerInterfaceType = typeof(ICommandHandler<>);

            if (typeInterfaceCollection!.Any(q => q.GetGenericTypeDefinition() == handlerInterfaceType))
                throw new ArgumentOutOfRangeException($"The {nameof(commandType)} argument must implement {handlerInterfaceType.Name}<>");

            if (typeInterfaceCollection!.Any(q =>
                q.GetGenericTypeDefinition() == handlerInterfaceType
                && q.GetGenericArguments().Any(q1 => q1 == handlerType)
            ))
                throw new ArgumentOutOfRangeException($"The {nameof(handlerType)} must be a same type of generic argument for {nameof(commandType)} argument.");

            _commandHandlerRegistrationsCollection.Add(new HandlerRegistration
            {
                MessageType = commandType,
                HandlerType = handlerType,
                Order = order,
                StopOnError = stopOnError,
                IsAsync = isAsync
            });
        }
        public void RegisterQueryHandler(Type queryType, Type handlerType, double order, bool stopOnError, bool isAsync)
        {
            var typeInterfaceCollection = queryType.GetInterfaces();
            var handlerInterfaceType = typeof(IQueryHandler<>);

            if (typeInterfaceCollection!.Any(q => q.GetGenericTypeDefinition() == handlerInterfaceType))
                throw new ArgumentOutOfRangeException($"The {nameof(queryType)} argument must implement {handlerInterfaceType.Name}<>");

            if (typeInterfaceCollection!.Any(q =>
                q.GetGenericTypeDefinition() == handlerInterfaceType
                && q.GetGenericArguments().Any(q1 => q1 == handlerType)
            ))
                throw new ArgumentOutOfRangeException($"The {nameof(handlerType)} must be a same type of generic argument for {nameof(queryType)} argument.");

            _queryHandlerRegistrationsCollection.Add(new HandlerRegistration
            {
                MessageType = queryType,
                HandlerType = handlerType,
                Order = order,
                StopOnError = stopOnError,
                IsAsync = isAsync
            });
        }
        public void RegisterEventHandler(Type eventType, Type handlerType, double order, bool isAsync)
        {
            var typeInterfaceCollection = eventType.GetInterfaces();
            var handlerInterfaceType = typeof(IEventHandler<>);

            if (typeInterfaceCollection!.Any(q => q.GetGenericTypeDefinition() == handlerInterfaceType))
                throw new ArgumentOutOfRangeException($"The {nameof(eventType)} argument must implement {handlerInterfaceType.Name}<>");

            if (typeInterfaceCollection!.Any(q =>
                q.GetGenericTypeDefinition() == handlerInterfaceType
                && q.GetGenericArguments().Any(q1 => q1 == handlerType)
            ))
                throw new ArgumentOutOfRangeException($"The {nameof(handlerType)} must be a same type of generic argument for {nameof(eventType)} argument.");

            _eventHandlerRegistrationsCollection.Add(new HandlerRegistration
            {
                MessageType = eventType,
                HandlerType = handlerType,
                Order = order,
                StopOnError = false,
                IsAsync = isAsync
            });
        }
    }
}

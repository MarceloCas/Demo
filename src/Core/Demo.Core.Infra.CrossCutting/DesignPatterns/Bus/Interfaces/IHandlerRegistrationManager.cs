using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using System;
using System.Collections.Generic;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public interface IHandlerRegistrationManager
    {
        ICollection<HandlerRegistration> DomainNotificationHandlerRegistrationsCollection { get; }
        ICollection<HandlerRegistration> CommandHandlerRegistrationsCollection { get; }
        ICollection<HandlerRegistration> QueryHandlerRegistrationsCollection { get; }
        ICollection<HandlerRegistration> EventHandlerRegistrationsCollection { get; }

        void RegisterDomainNotificationHandler(Type domainNotificationType, Type handlerType, double order, bool isAsync);
        void RegisterCommandHandler(Type commandType, Type handlerType, double order, bool stopOnError, bool isAsync);
        void RegisterQueryHandler(Type queryType, Type handlerType, double order, bool stopOnError, bool isAsync);
        void RegisterEventHandler(Type eventType, Type handlerType, double order, bool isAsync);
    }
}

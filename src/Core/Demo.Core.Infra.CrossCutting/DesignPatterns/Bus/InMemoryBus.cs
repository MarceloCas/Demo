using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus
{
    public class InMemoryBus
        : IBus
    {
        private readonly List<HandleRegistration> _domainNotificationHandleRegistrationCollection;
        private readonly List<HandleRegistration> _commandHandleRegistrationCollection;
        private readonly List<HandleRegistration> _queryHandleRegistrationCollection;
        private readonly List<HandleRegistration> _eventHandleRegistrationCollection;

        public InMemoryBus()
        {
            _domainNotificationHandleRegistrationCollection = new List<HandleRegistration>();
            _commandHandleRegistrationCollection = new List<HandleRegistration>();
            _queryHandleRegistrationCollection = new List<HandleRegistration>();
            _eventHandleRegistrationCollection = new List<HandleRegistration>();
        }

        public void RegisterDomainNotificationHandler<TDomainNotification>(IHandler<TDomainNotification> handler, double order, bool isAsync) 
            where TDomainNotification : DomainNotification
        {
            _domainNotificationHandleRegistrationCollection.Add(new HandleRegistration { 
                Handler = handler,
                Order = order,
                IsAsync = isAsync
            });
        }
        public void RegisterCommandHandler<TCommand>(IHandler<TCommand> handler, double order, bool isAsync) where TCommand : Command
        {
            _commandHandleRegistrationCollection.Add(new HandleRegistration
            {
                Handler = handler,
                Order = order,
                IsAsync = isAsync
            });
        }
        public void RegisterEventHandler<TEvent>(IHandler<TEvent> handler, double order, bool isAsync) where TEvent : Event
        {
            _eventHandleRegistrationCollection.Add(new HandleRegistration
            {
                Handler = handler,
                Order = order,
                IsAsync = isAsync
            });
        }
        public void RegisterQueryHandler<TQuery>(IHandler<TQuery> handler, double order, bool isAsync) where TQuery : QueryBase
        {
            _queryHandleRegistrationCollection.Add(new HandleRegistration
            {
                Handler = handler,
                Order = order,
                IsAsync = isAsync
            });
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

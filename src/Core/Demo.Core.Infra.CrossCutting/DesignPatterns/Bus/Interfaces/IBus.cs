using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public interface IBus
        : IDisposable
    {
        void RegisterDomainNotificationHandler<TDomainNotification>(IHandler<TDomainNotification> handler, double order, bool isAsync)
            where TDomainNotification : DomainNotification;
        void RegisterCommandHandler<TCommand>(IHandler<TCommand> handler, double order, bool isAsync)
            where TCommand : Command;
        void RegisterQueryHandler<TQuery>(IHandler<TQuery> handler, double order, bool isAsync)
            where TQuery : QueryBase;
        void RegisterEventHandler<TEvent>(IHandler<TEvent> handler, double order, bool isAsync)
            where TEvent : Event;
    }
}

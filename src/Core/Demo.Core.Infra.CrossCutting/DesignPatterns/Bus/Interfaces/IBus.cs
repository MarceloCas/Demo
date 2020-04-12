using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using System;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public interface IBus
        : IDisposable
    {
        Task<bool> SendDomainNotificationAsync<TDomainNotification>(TDomainNotification domainNotification)
            where TDomainNotification : DomainNotification;
        Task<bool> SendCommandAsync<TCommand>(TCommand domainNotification)
            where TCommand : Command;
        Task<TQuery> SendQueryAsync<TQuery>(TQuery query)
            where TQuery : QueryBase;
        Task<bool> SendEventAsync<TEvent>(TEvent @event)
            where TEvent : Event;
    }
}

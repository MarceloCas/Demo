using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public interface IBus
        : IDisposable
    {
        Task<bool> SendDomainNotificationAsync(DomainNotification domainNotification);
        Task<bool> SendCommandAsync<TCommand>(TCommand domainNotification)
            where TCommand : Command;
    }
}

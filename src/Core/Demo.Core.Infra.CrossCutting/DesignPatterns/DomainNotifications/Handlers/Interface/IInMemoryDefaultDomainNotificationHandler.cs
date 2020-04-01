using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface
{
    public interface IInMemoryDefaultDomainNotificationHandler
        : IDomainNotificationHandler<DomainNotification>
    {
    }
}

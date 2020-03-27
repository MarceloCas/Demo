using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface
{
    public interface IDomainNotificationHandler
        : IHandler<DomainNotification>
    {
        ICollection<DomainNotification> DomainNotificationsCollection { get; }

        Task<bool> Handle(DomainNotification domainNotification);

        void AddDomainNotification(DomainNotificationTypeEnum type, string code, string defaultDescription);
        void AddDomainNotification(DomainNotification domainNotification);
        void AddDomainNotificationFromValidationResult(ValidationResult validationResult);
    }
}

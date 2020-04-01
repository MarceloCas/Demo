using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface
{
    public interface IDomainNotificationHandler<TDomainNotification>
        : IHandler<TDomainNotification>
        where TDomainNotification : DomainNotification
    {
        ICollection<TDomainNotification> DomainNotificationsCollection { get; }

        Task<bool> HandleAsync(TDomainNotification domainNotification);

        void AddDomainNotification(DomainNotificationTypeEnum type, string code, string defaultDescription);
        void AddDomainNotification(TDomainNotification domainNotification);
        void AddDomainNotificationFromValidationResult(ValidationResult validationResult);
    }
}

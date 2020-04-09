using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface
{
    public delegate Task<bool> DomainNotificationHandler<TDomainNotification>(TDomainNotification domainNotification) where TDomainNotification : DomainNotification;

    public interface IDomainNotificationHandler<TDomainNotification>
        : IHandler<TDomainNotification>
        where TDomainNotification : DomainNotification
    {
        // Properties
        ICollection<TDomainNotification> DomainNotificationsCollection { get; }
        DomainNotificationHandler<TDomainNotification> DomainNotificationHandler { get; }

        // Methods
        void AddDomainNotification(DomainNotificationTypeEnum type, string code, string defaultDescription);
        void AddDomainNotification(TDomainNotification domainNotification);
        void AddDomainNotificationFromValidationResult(ValidationResult validationResult);
    }
}

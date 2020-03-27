using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers
{
    public class DefaultDomainNotificationHandler
        : IDomainNotificationHandler
    {
        // Attributes
        private readonly List<DomainNotification> _domainNotificationsCollection;

        // Properties
        public ICollection<DomainNotification> DomainNotificationsCollection
        {
            get
            {
                return _domainNotificationsCollection;
            }
        }

        // Constructors
        public DefaultDomainNotificationHandler()
        {
            _domainNotificationsCollection = new List<DomainNotification>();
        }

        // Public Methods
        public void AddDomainNotification(DomainNotification domainNotification)
        {
            _domainNotificationsCollection.Add(domainNotification);
        }
        public void AddDomainNotification(DomainNotificationTypeEnum type, string code, string defaultDescription)
        {
            AddDomainNotification(new DomainNotification() { 
                Type = type,
                Code = code,
                DefaultDescription = defaultDescription
            });
        }
        public void AddDomainNotificationFromValidationResult(ValidationResult validationResult)
        {
            foreach (var message in validationResult.Messages)
            {
                var domainNotificationType = message.ValidationMessageType switch
                {
                    Specification.Enums.ValidationMessageTypeEnum.Info => DomainNotificationTypeEnum.Info,
                    Specification.Enums.ValidationMessageTypeEnum.Warning => DomainNotificationTypeEnum.Warning,
                    Specification.Enums.ValidationMessageTypeEnum.Error => DomainNotificationTypeEnum.Error,
                    _ => DomainNotificationTypeEnum.Info,
                };

                AddDomainNotification(
                    domainNotificationType,
                    message.Code,
                    message.DefaultDescription);
            }
        }
        public async Task<bool> Handle(DomainNotification domainNotification)
        {
            DomainNotificationsCollection.Add(domainNotification);

            return await Task.FromResult(true);
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

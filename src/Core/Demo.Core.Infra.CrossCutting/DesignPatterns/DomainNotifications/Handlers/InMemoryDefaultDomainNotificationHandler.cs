using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Enums;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers
{
    public class InMemoryDefaultDomainNotificationHandler
        : DomainNotificationHandlerBase<DomainNotification>,
        IInMemoryDefaultDomainNotificationHandler
    {
        // Protected Methods
        protected override DomainNotificationHandler<DomainNotification> GetDomainNotificationHandler()
        {
            return async domainNotification => {
                DomainNotificationsCollection.Add(domainNotification);

                return await Task.FromResult(true);
            };
        }

        // Constructors
        public InMemoryDefaultDomainNotificationHandler() 
            : base()
        {

        }

        // Public Methods
        public override void AddDomainNotification(DomainNotification domainNotification)
        {
            DomainNotificationsCollection.Add(domainNotification);
        }
        public override void AddDomainNotification(DomainNotificationTypeEnum type, string code, string defaultDescription)
        {
            AddDomainNotification(new DomainNotification() { 
                Type = type,
                Code = code,
                DefaultDescription = defaultDescription
            });
        }
        public override void AddDomainNotificationFromValidationResult(ValidationResult validationResult)
        {
            foreach (var message in validationResult.ValidationMessagesCollection)
            {
                var domainNotificationType = message.ValidationMessageType switch
                {
                    ValidationMessageTypeEnum.Info => DomainNotificationTypeEnum.Info,
                    ValidationMessageTypeEnum.Warning => DomainNotificationTypeEnum.Warning,
                    ValidationMessageTypeEnum.Error => DomainNotificationTypeEnum.Error,
                    _ => DomainNotificationTypeEnum.Info,
                };

                AddDomainNotification(
                    domainNotificationType,
                    message.Code,
                    message.DefaultDescription);
            }
        }
    }
}

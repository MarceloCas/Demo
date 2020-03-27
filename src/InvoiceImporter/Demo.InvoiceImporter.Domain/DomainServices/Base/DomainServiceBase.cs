using Demo.Core.Domain.DomainModels.Base.Interfaces;
using Demo.Core.Domain.DomainServices.Base.Interfaces;
using Demo.Core.Domain.Repositories.Base.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices.Base
{
    public class DomainServiceBase<TAuditableDomainModel>
        : Core.Domain.DomainServices.Base.DomainServiceBase<TAuditableDomainModel>
        where TAuditableDomainModel : IAuditableDomainModel
    {
        // Constructors
        public DomainServiceBase(
            IBus bus,
            IFactory<TAuditableDomainModel> factory)
            : base(bus, factory)
        {

        }

        // Protected Methods
        protected async Task<bool> Validate<T>(T entity, IValidator<T> validator)
        {
            var validationResult = await validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                foreach (var validationMessage in validationResult.ValidationMessagesCollection)
                {
                    await Bus.SendDomainNotification(new DomainNotification()
                    {
                        Code = validationMessage.Code,
                        DefaultDescription = validationMessage.DefaultDescription,
                        Type = validationMessage.ValidationMessageType switch
                        {
                            Core.Infra.CrossCutting.DesignPatterns.Specification.Enums.ValidationMessageTypeEnum.Info => DomainNotificationTypeEnum.Info,
                            Core.Infra.CrossCutting.DesignPatterns.Specification.Enums.ValidationMessageTypeEnum.Warning => DomainNotificationTypeEnum.Warning,
                            Core.Infra.CrossCutting.DesignPatterns.Specification.Enums.ValidationMessageTypeEnum.Error => DomainNotificationTypeEnum.Error,
                            _ => DomainNotificationTypeEnum.Info,
                        }
                    });
                }
            }

            return validationResult.IsValid;
        }
    }
}

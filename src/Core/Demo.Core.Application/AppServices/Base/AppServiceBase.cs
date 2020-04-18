using Demo.Core.Application.AppServices.Interfaces;
using Demo.Core.Domain.ValueObjects;
using Demo.Core.Domain.ValueObjects.Factories.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.Core.Application.AppServices.Base
{
    public abstract class AppServiceBase
        : IAppService
    {
        // Properties
        protected IBus Bus { get; }
        protected IGlobalizationConfig GlobalizationConfig { get; }
        protected TenantInfoValueObject TenantInfoValueObject { get; }


        // Constructors
        protected AppServiceBase(
            IBus bus,
            IGlobalizationConfig globalizationConfig,
            ITenantInfoValueObjectFactory tenantInfoValueObjectFactory
            )
        {
            Bus = bus;
            GlobalizationConfig = globalizationConfig;
            TenantInfoValueObject = tenantInfoValueObjectFactory.CreateAsync().GetAwaiter().GetResult();
        }

        // Protected Methods
        protected async Task<bool> ValidateAsync<T>(T entity, IValidator<T> validator)
        {
            var validationResult = await validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                foreach (var validationMessage in validationResult.ValidationMessagesCollection)
                {
                    await Bus.SendDomainNotificationAsync(new DomainNotification()
                    {
                        Code = validationMessage.Code,
                        DefaultDescription = validationMessage.DefaultDescription,
                        Type = validationMessage.ValidationMessageType switch
                        {
                            Infra.CrossCutting.DesignPatterns.Specification.Enums.ValidationMessageTypeEnum.Info => DomainNotificationTypeEnum.Info,
                            Infra.CrossCutting.DesignPatterns.Specification.Enums.ValidationMessageTypeEnum.Warning => DomainNotificationTypeEnum.Warning,
                            Infra.CrossCutting.DesignPatterns.Specification.Enums.ValidationMessageTypeEnum.Error => DomainNotificationTypeEnum.Error,
                            _ => DomainNotificationTypeEnum.Info,
                        }
                    });
                }
            }

            return validationResult.IsValid;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

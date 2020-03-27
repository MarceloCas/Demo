using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using Demo.Core.Infra.CrossCutting.Globalization;
using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.IoC
{
    public class DefaultBootstrapper
    {
        public void RegisterServices(
            IServiceCollection services, 
            string cultureName,
            LocalizationsEnum localization)
        {
            services.AddScoped<IGlobalizationConfig>(serviceProvider => 
            {
                return new GlobalizationConfig(cultureName, localization); 
            });

            services.AddScoped<IBus>(serviceProvider => {
                return new InMemoryBus(serviceProvider);
            });
        }
    }
}

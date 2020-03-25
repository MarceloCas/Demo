using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Interfaces;
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
            string cultureCode,
            LocalizationsEnum localization)
        {
            services.AddScoped<IGlobalizationConfig>(serviceProvider => 
            {
                return new GlobalizationConfig(cultureCode, localization); 
            });
        }
    }
}

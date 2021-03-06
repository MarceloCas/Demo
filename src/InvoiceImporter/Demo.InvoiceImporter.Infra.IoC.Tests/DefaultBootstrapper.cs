﻿using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.InvoiceImporter.Infra.IoC.Tests
{
    public class DefaultBootstrapper
        : IoC.DefaultBootstrapper
    {
        public DefaultBootstrapper(
            IServiceCollection services,
            string tenantCode,
            string cultureName,
            LocalizationsEnum localization
            ) : base(services, tenantCode, cultureName, localization)
        {
        }
    }
}

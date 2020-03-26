using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.Globalization
{
    public class GlobalizationConfig
        : IGlobalizationConfig
    {
        public CultureInfo CultureInfo { get; protected set; }
        public LocalizationsEnum Localization { get; protected set; }

        public GlobalizationConfig(
            string cultureName, 
            LocalizationsEnum localization) 
        {
            CultureInfo = new CultureInfo(cultureName);
            Localization = localization;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

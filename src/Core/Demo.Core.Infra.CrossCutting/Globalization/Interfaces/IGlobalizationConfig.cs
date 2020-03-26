using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.Globalization.Interfaces
{
    public interface IGlobalizationConfig
        : IDisposable
    {
        CultureInfo CultureInfo { get; }
        LocalizationsEnum Localization { get; }
    }
}

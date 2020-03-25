using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Interfaces
{
    public interface IGlobalizationConfig
        : IDisposable
    {
        CultureInfo CultureInfo { get; }
        LocalizationsEnum Localization { get; }
    }
}

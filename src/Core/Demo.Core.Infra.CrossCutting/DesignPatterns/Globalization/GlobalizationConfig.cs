using Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Globalization
{
    public class GlobalizationConfig
        : IGlobalizationConfig
    {
        public CultureInfo CultureInfo { get; protected set; }

        public GlobalizationConfig(string cultureCode) 
        {
            CultureInfo = new CultureInfo(cultureCode);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static bool LengthIsBetween(this string str, int min, int max)
        {
            return str.Length >= min && str.Length <= max;
        }
    }
}

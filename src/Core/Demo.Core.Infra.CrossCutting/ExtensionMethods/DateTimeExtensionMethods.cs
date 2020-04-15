using System;

namespace Demo.Core.Infra.CrossCutting.ExtensionMethods
{
    public static class DateTimeExtensionMethods
    {

        public static bool IsGreatherThan(this DateTime dt, DateTime min, bool acceptMinValue = true)
        {
            return
                (acceptMinValue ? true : dt > DateTime.MinValue) 
                && dt >= min;
        }
        public static bool IsLessThan(this DateTime dt, DateTime max, bool acceptMinValue = true)
        {
            return
                (acceptMinValue ? true : dt > DateTime.MinValue)
                && dt <= max;
        }
        public static bool IsBetween(this DateTime dt, DateTime min, DateTime max)
        {
            return dt >= min && dt <= max;
        }
    }
}

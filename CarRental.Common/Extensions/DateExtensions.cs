using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Common.Extensions
{
    public static class DateExtensions
    {
        public static int DurationDays(this DateTime startDate, DateTime endDate)
        {
            var span = endDate - startDate;
            return span.Days + 1;
        }
    }
}

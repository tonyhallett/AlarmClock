using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class DateTimeExtensions
    {
        public static HoursMinutesSecondsDigits Digits(this DateTime dateTime)
        {
            return new HoursMinutesSecondsDigits
            {
                Hours = new DateTimeDigits(dateTime.Hour),
                Minutes = new DateTimeDigits(dateTime.Minute),
                Seconds = new DateTimeDigits(dateTime.Second)
            };
        }
    }
}

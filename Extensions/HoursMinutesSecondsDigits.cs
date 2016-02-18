using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public class HoursMinutesSecondsDigits
    {
        public DateTimeDigits Hours { get; set; }
        public DateTimeDigits Minutes { get; set; }
        public DateTimeDigits Seconds { get; set; }
        public static HoursMinutesSecondsChange operator -(HoursMinutesSecondsDigits first, HoursMinutesSecondsDigits second)
        {
            HoursMinutesSecondsChange change = HoursMinutesSecondsChange.None;
            change=PartChange(change, first.Hours, second.Hours, HoursMinutesSecondsChange.HoursFirst, HoursMinutesSecondsChange.HoursSecond);
            change=PartChange(change, first.Minutes, second.Minutes, HoursMinutesSecondsChange.MinutesFirst, HoursMinutesSecondsChange.MinutesSecond);
            change=PartChange(change, first.Seconds, second.Seconds, HoursMinutesSecondsChange.SecondsFirst, HoursMinutesSecondsChange.SecondsSecond);
            return change;
        }
        private static HoursMinutesSecondsChange PartChange(HoursMinutesSecondsChange currentValue,DateTimeDigits first,DateTimeDigits second,HoursMinutesSecondsChange firstValue,HoursMinutesSecondsChange secondValue)
        {
            var digitChange = first - second;
            if (digitChange.HasFlag(DigitChange.First))
            {
                currentValue |= firstValue;
            }
            if (digitChange.HasFlag(DigitChange.Second))
            {
                currentValue |= secondValue;
            }
            return currentValue;
        }

        public int GetChangeValue(HoursMinutesSecondsChange c)
        {
            var changeValue = 0;
            switch (c)
            {
                case HoursMinutesSecondsChange.HoursFirst:
                    changeValue = Hours.First;
                    break;
                case HoursMinutesSecondsChange.HoursSecond:
                    changeValue = Hours.Second;
                    break;
                case HoursMinutesSecondsChange.MinutesFirst:
                    changeValue = Minutes.First;
                    break;
                case HoursMinutesSecondsChange.MinutesSecond:
                    changeValue = Minutes.Second;
                    break;
                case HoursMinutesSecondsChange.SecondsFirst:
                    changeValue = Seconds.First;
                    break;
                case HoursMinutesSecondsChange.SecondsSecond:
                    changeValue = Seconds.Second;
                    break;
            }
            return changeValue;
        }
    }
    [Flags]
    public enum HoursMinutesSecondsChange { None=0,HoursFirst=1,HoursSecond=2,MinutesFirst=4,MinutesSecond=8,SecondsFirst=16,SecondsSecond=32}
}

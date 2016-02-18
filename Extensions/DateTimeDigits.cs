using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public class DateTimeDigits
    {
        public DateTimeDigits(int hoursOrMinutesOrSeconds)
        {
            int outSecond;
            First = Math.DivRem(hoursOrMinutesOrSeconds, 10, out outSecond);
            Second = outSecond;
        }
        public static DigitChange operator -(DateTimeDigits first, DateTimeDigits second)
        {
            DigitChange change = DigitChange.None;
            if (first.First - second.First!=0)
            {
                change |= DigitChange.First;
            }
            if (first.Second - second.Second!=0)
            {
                change |= DigitChange.Second;
            }
            return change;
        }
        public int First { get; set; }
        public int Second { get; set; }
    }
    [Flags]
    public enum DigitChange { None=0,First=1,Second=2}
}

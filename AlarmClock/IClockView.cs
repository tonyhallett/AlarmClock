using System;

namespace AlarmClock
{
    internal interface IClockView
    {
        DateTime Time { set; }
    }
}
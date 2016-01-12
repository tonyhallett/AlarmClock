using System;

namespace AlarmClock
{
    internal class Alarm
    {
        internal int Duration { get; set; }
        internal DateTime Time { get; set; }
        internal bool Called { get; set; }

    }
}
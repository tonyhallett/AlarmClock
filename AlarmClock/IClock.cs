using System;

namespace AlarmClock
{
    internal interface IClock
    {
        event EventHandler<DateTime> Tick;
    }
}
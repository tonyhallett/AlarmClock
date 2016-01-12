

using System;

namespace AlarmClock
{
    internal interface IAlarmClock:IClock
    {
        event EventHandler<int> Alarm;
    }
}
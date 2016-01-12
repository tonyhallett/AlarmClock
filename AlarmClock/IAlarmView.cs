using System;

namespace AlarmClock
{
    internal interface IAlarmView
    {
        event EventHandler<Alarm> AlarmSet;
    }
}
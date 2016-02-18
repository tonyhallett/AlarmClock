

using Interfaces;
using System;

namespace AlarmClock
{
    internal interface IAlarmClock:IClock
    {
        event EventHandler<int> Alarm;

        void SetAlarm(Alarm newAlarm);
    }
}
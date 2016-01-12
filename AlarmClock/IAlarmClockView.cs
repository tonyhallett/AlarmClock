using System;

namespace AlarmClock
{
    internal interface IAlarmClockView
    {
        event EventHandler TurnOffAlarm;
        void StartAlarm();
        void StopAlarm();
    }
}
using System;

namespace Interfaces
{
    public interface IAlarmClockView
    {
        event EventHandler TurnOffAlarm;
        void StartAlarm();
        void StopAlarm();
        
    }
}
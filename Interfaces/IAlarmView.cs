using System;

namespace Interfaces
{
    public interface IAlarmView
    {
        event EventHandler<Alarm> AlarmSet;
        
    }
}
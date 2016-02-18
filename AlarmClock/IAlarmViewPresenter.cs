using Interfaces;
using System;

namespace AlarmClock
{
    internal interface IAlarmViewPresenter
    {
        event EventHandler<Alarm> AlarmSet;
        
    }
}
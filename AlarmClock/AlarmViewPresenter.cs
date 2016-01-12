using System;

namespace AlarmClock
{
    internal class AlarmViewPresenter:IAlarmViewPresenter
    {
        private IAlarmView alarmView;

        internal AlarmViewPresenter(IAlarmView alarmView)
        {
            this.alarmView = alarmView;
        }

        public event EventHandler<Alarm> AlarmSet;
    }
}
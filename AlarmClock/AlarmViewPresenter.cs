using System;

namespace AlarmClock
{
    internal class AlarmViewPresenter:IAlarmViewPresenter
    {
        private IAlarmView alarmView;

        internal AlarmViewPresenter(IAlarmView alarmView)
        {
            this.alarmView = alarmView;
            this.alarmView.AlarmSet += AlarmView_AlarmSet;
        }

        private void AlarmView_AlarmSet(object sender, Alarm e)
        {
            var handler = AlarmSet;
            if (AlarmSet != null)
            {
                AlarmSet(this, e);
            }
        }

        public event EventHandler<Alarm> AlarmSet;
    }
}
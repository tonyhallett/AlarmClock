

namespace AlarmClock
{
    internal class AlarmClockViewPresenter
    {
        private IClockPresenter clockPresenter;
        private IAlarmClock alarmClock;
        

        internal AlarmClockViewPresenter(IAlarmClock alarmClock, IClockPresenter clockPresenter)
        {
            this.alarmClock = alarmClock;
            alarmClock.Tick += AlarmClock_Tick;
            this.clockPresenter = clockPresenter;
        }

        private void AlarmClock_Tick(object sender, System.DateTime e)
        {
            clockPresenter.Time = e;
        }
    }
}
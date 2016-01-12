

namespace AlarmClock
{
    internal class AlarmClockViewPresenter
    {
        private IClockPresenter clockPresenter;
        private IAlarmClock alarmClock;
        private IAlarmClockView alarmClockView;
        
       

        public AlarmClockViewPresenter(IAlarmClockView alarmClockView, IAlarmClock alarmClock, IClockPresenter clockPresenter)
        {
            this.alarmClockView = alarmClockView;
            this.alarmClock = alarmClock;
            this.clockPresenter = clockPresenter;
        }

        private void AlarmClock_Tick(object sender, System.DateTime e)
        {
            clockPresenter.Time = e;
        }
    }
}
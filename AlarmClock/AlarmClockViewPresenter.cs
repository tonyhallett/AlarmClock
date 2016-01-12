

namespace AlarmClock
{
    internal class AlarmClockViewPresenter
    {
        private IClockPresenter clockPresenter;
        private IAlarmClock alarmClock;
        private IAlarmClockView alarmClockView;
        private System.Timers.Timer timer;



        public AlarmClockViewPresenter(IAlarmClockView alarmClockView, IAlarmClock alarmClock, IClockPresenter clockPresenter)
        {
            this.alarmClockView = alarmClockView;
            this.alarmClock = alarmClock;
            this.alarmClock.Tick += AlarmClock_Tick;
            this.alarmClock.Alarm += AlarmClock_Alarm;
            this.clockPresenter = clockPresenter;
        }

        private void AlarmClock_Alarm(object sender, int e)
        {
            timer = new System.Timers.Timer(e * 1000);
            alarmClockView.StartAlarm();
            timer.Start();

            timer.Elapsed += (sndr, args) =>
            {
                alarmClockView.StopAlarm();
            };
        }
        
        private void AlarmClock_Tick(object sender, System.DateTime e)
        {
            clockPresenter.Time = e;
        }
    }
}
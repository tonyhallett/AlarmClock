

using Interfaces;

namespace AlarmClock
{
    internal class AlarmClockViewPresenter
    {
        private IClockViewPresenter clockPresenter;
        private IAlarmClock alarmClock;
        private IAlarmClockView alarmClockView;
        private System.Timers.Timer timer;
        private IAlarmViewPresenter alarmViewPresenter;
        public IAlarmClockView View { get
            {
                return alarmClockView;
            }
        }
            
        public AlarmClockViewPresenter(IAlarmClockView alarmClockView, IAlarmClock alarmClock, IClockViewPresenter clockPresenter, IAlarmViewPresenter alarmViewPresenter)
        {
            this.alarmClockView = alarmClockView;
            this.alarmClockView.TurnOffAlarm += AlarmClockView_TurnOffAlarm;
            this.alarmClock = alarmClock;
            this.alarmClock.Tick += AlarmClock_Tick;
            this.alarmClock.Alarm += AlarmClock_Alarm;
            this.clockPresenter = clockPresenter;
            this.alarmViewPresenter = alarmViewPresenter;
            this.alarmViewPresenter.AlarmSet += AlarmViewPresenter_AlarmSet;
        }

        private void AlarmClockView_TurnOffAlarm(object sender, System.EventArgs e)
        {
            alarmClockView.StopAlarm();
        }

        private void AlarmViewPresenter_AlarmSet(object sender, Alarm e)
        {
            alarmClock.SetAlarm(e);
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
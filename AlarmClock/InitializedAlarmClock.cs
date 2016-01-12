using System;

namespace AlarmClock
{
    internal class InitializedAlarmClock:InitializedClock,IAlarmClock
    {
        private Alarm alarm;
        internal InitializedAlarmClock(DateTime initialTime):base(initialTime)
        {
            this.Tick += InitializedAlarmClock_Tick;       
        }

        private void InitializedAlarmClock_Tick(object sender, DateTime e)
        {
            
        }

        public event EventHandler<int> Alarm;
        
        public void SetAlarm(Alarm newAlarm)
        {
            alarm = newAlarm;
        }
    }
}
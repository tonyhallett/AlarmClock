using Interfaces;
using System;

namespace AlarmClock
{
    public class InitializedAlarmClock:InitializedClock,IAlarmClock
    {
        private Alarm setAlarm;
        public InitializedAlarmClock(DateTime initialTime):base(initialTime)
        {
            this.Tick += InitializedAlarmClock_Tick;       
        }

        private void InitializedAlarmClock_Tick(object sender, DateTime e)
        {
            if (setAlarm != null&&!setAlarm.Called&&setAlarm.Time<e)
            {
                setAlarm.Called = true;
                var handler = Alarm;
                if (handler != null)
                {
                    handler(this, setAlarm.Duration);
                }
            }
        }

        public event EventHandler<int> Alarm;
        
        public void SetAlarm(Alarm newAlarm)
        {
            setAlarm = newAlarm;
        }
    }
}
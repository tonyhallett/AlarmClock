using System;
using System.Timers;

namespace AlarmClock
{
    public  class InitializedClock:IClock
    {
        private DateTime now;
        private Timer timer;
        private int tickCount = 0;
        internal InitializedClock(DateTime now)
        {
            this.now = now;
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var handler = Tick;
            if (handler != null)
            {
                handler(this, now.AddSeconds(tickCount));

            }
            tickCount++;
        }

        public event EventHandler<DateTime> Tick;
    }
}
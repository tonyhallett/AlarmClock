using System;

namespace AlarmClock
{
    internal class ClockViewPresenter:IClockViewPresenter
    {
        private IClockView clockView;

        public ClockViewPresenter(IClockView clockView)
        {
            this.clockView = clockView;
        }

        public DateTime Time
        {
            set
            {
                clockView.Time = value;
            }
        }
    }
}
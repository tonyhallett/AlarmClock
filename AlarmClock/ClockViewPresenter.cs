using System;

namespace AlarmClock
{
    internal class ClockViewPresenter:IClockViewPresenter
    {
        private IClockView clockView;

        internal ClockViewPresenter(IClockView clockView)
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
using AlarmClock;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClockTests
{
    [TestFixture]
    public class AlarmClockViewPresenterTests:AssertionHelper
    {
        [Test]
        public void Should_Set_The_ClockPresenter_Time_When_The_AlarmClock_Raises_The_Tick_Event()
        {
            var now = DateTime.Now;
            var mockAlarmClock = new Mock<IAlarmClock>();
            var mockClockPresenter = new Mock<IClockPresenter>();
            mockClockPresenter.SetupSet(cp => cp.Time = now).Verifiable();
            var alarmClockViewPresenter = new AlarmClockViewPresenter(mockAlarmClock.Object,mockClockPresenter.Object);
            
            
            mockAlarmClock.Raise(ac => ac.Tick += null, mockAlarmClock.Object,now);
            Expect(() => { mockClockPresenter.Verify(); }, Throws.Nothing);
        }
        [Test]
        public void Should_StartAlarm_When_AlarmClock_Raises_Alarm_And_StopAlarm_When_Duration_Is_Over()
        {

        }
    }
}

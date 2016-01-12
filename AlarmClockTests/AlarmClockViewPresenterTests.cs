using AlarmClock;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlarmClockTests
{
    [TestFixture]
    public class AlarmClockViewPresenterTests:AssertionHelper
    {
        private AlarmClockViewPresenter alarmClockViewPresenter;
        private Mock<IAlarmClock> mockAlarmClock;
        private Mock<IAlarmClockView> mockAlarmClockView;
        private Mock<IClockViewPresenter> mockClockViewPresenter;
        private IAlarmClock mockedAlarmClock;
        private IAlarmClockView mockedAlarmClockView;
        private IClockViewPresenter mockedClockViewPresenter;
        private Mock<IAlarmViewPresenter> mockAlarmViewPresenter;
        private IAlarmViewPresenter mockedAlarmViewPresenter;

        [SetUp]
        public void SetUp()
        {
            mockAlarmClock = new Mock<IAlarmClock>();
            mockedAlarmClock = mockAlarmClock.Object;
            mockClockViewPresenter = new Mock<IClockViewPresenter>();
            mockedClockViewPresenter = mockClockViewPresenter.Object;
            mockAlarmClockView = new Mock<IAlarmClockView>();
            mockedAlarmClockView = mockAlarmClockView.Object;
            mockAlarmViewPresenter = new Mock<IAlarmViewPresenter>();
            mockedAlarmViewPresenter = mockAlarmViewPresenter.Object;
            alarmClockViewPresenter = new AlarmClockViewPresenter(mockedAlarmClockView, mockedAlarmClock, mockedClockViewPresenter,mockedAlarmViewPresenter);
        }
        [Test]
        public void Should_Set_The_ClockPresenter_Time_When_The_AlarmClock_Raises_The_Tick_Event()
        {
            var now = DateTime.Now;
            mockClockViewPresenter.SetupSet(cp => cp.Time = now).Verifiable();
            
            mockAlarmClock.Raise(ac => ac.Tick += null, mockAlarmClock.Object,now);
            Expect(() => { mockClockViewPresenter.Verify(); }, Throws.Nothing);
        }
        [Test]
        public void Should_StartAlarm_On_View_When_AlarmClock_Raises_Alarm_And_StopAlarm_When_Duration_Is_Over()
        {
            var duration = 10;//seconds
            DateTime startAlarmTime = DateTime.Now;
            DateTime stopAlarmTime = DateTime.Now;
            mockAlarmClockView.Setup(v => v.StartAlarm()).Callback(() =>
            {
                startAlarmTime = DateTime.Now;
            }).Verifiable();
            mockAlarmClockView.Setup(v => v.StopAlarm()).Callback(() =>
            {
                stopAlarmTime = DateTime.Now;
            }).Verifiable();
            
            mockAlarmClock.Raise(ac => ac.Alarm += null, mockedAlarmClock, duration);
            Thread.Sleep((duration+5)*1000);
            Expect(() => { mockAlarmClockView.Verify(); }, Throws.Nothing);
            
            Expect((stopAlarmTime - startAlarmTime).Seconds, Is.GreaterThanOrEqualTo(duration));
            
        }
        [Test]
        public void Should_Set_AlarmClock_Alarm_When_AlarmViewPresenter_Sets_Alarm()
        {
            
            var newAlarm = new Alarm();
            mockAlarmViewPresenter.Raise(avp => avp.AlarmSet += null, mockAlarmViewPresenter.Object, newAlarm);
            Expect(() => { mockAlarmClock.Verify(ac => ac.SetAlarm(newAlarm)); }, Throws.Nothing);
        }
        [Test]
        public void Should_StopAlarm_If_AlarmClockView_TurnOffAlarm_Event_Is_Raised()
        {
            mockAlarmClockView.Raise(acv => acv.TurnOffAlarm += null, new EventArgs());
            Expect(() => { mockAlarmClockView.Verify(acv => acv.StopAlarm()); }, Throws.Nothing);
        }
    }
    [TestFixture]
    public class AlarmViewPresenterTests : AssertionHelper
    {
        [Test]
        public void Should_Raise_AlarmSet_When_View_Raise_Does_With_Same_Alarm()
        {
            var mockAlarmView = new Mock<IAlarmView>();
            var alarmView = mockAlarmView.Object;
            var alarmViewPresenter = new AlarmViewPresenter(alarmView);
            Alarm viewAlarm = new Alarm();
            Alarm setAlarm = null;
            alarmViewPresenter.AlarmSet +=(sender, args)=>{
                setAlarm = args;
            };
            mockAlarmView.Raise(v => v.AlarmSet += null, mockAlarmView.Object,viewAlarm);
            Expect(setAlarm, Is.SameAs(viewAlarm));
        }
    }
    [TestFixture]
    public class ClockViewPresenterTests : AssertionHelper
    {
        [Test]
        public void Should_Pass_Time_Through_To_View()
        {
            var mockClockView = new Mock<IClockView>();
            var clockView = mockClockView.Object;
            var clockViewPresenter = new ClockViewPresenter(clockView);
            var time = DateTime.Now;
            clockViewPresenter.Time = time;
            Expect(() => { mockClockView.VerifySet(cv => cv.Time = time); }, Throws.Nothing);
        }
    }
    [TestFixture]
    public class ClockTests : AssertionHelper
    {
        [Test]
        public void Should_Raise_Tick_At_Intervals_Of_One_Second_With_First_Tick_The_Initialized()
        {
            var initialTime = DateTime.Now;
            var clock = new InitializedClock(initialTime);
            var ticks = new List<DateTime>();
            clock.Tick += (sender, dt) =>
            {
                ticks.Add(dt);
            };
            Thread.Sleep(5000);
            var firstTick = ticks.First();
            Expect(firstTick, Is.EqualTo(initialTime));
            var lastTick = firstTick;
            for(var i = 1; i < ticks.Count; i++)
            {
                var nextTick = ticks[i];
                var duration = nextTick - lastTick;
                Expect(duration.TotalMilliseconds, Is.EqualTo(1000));
                lastTick = nextTick;
            }
        }
        
    }
    
}

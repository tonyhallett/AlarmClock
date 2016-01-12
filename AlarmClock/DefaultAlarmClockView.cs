using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class DefaultAlarmClockView : Form, IAlarmClockView
    {
        public DefaultAlarmClockView()
        {
            InitializeComponent();
            originalAlarmColor = this.BackColor;
        }

        public event EventHandler TurnOffAlarm;
        private Color originalAlarmColor;
        public void StartAlarm()
        {
            this.BackColor = Color.Red;
        }

        public void StopAlarm()
        {
            this.BackColor = originalAlarmColor;
        }
    }
}
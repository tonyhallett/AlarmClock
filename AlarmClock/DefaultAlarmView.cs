using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    internal partial class DefaultAlarmView : UserControl,IAlarmView
    {
        public DefaultAlarmView()
        {
            InitializeComponent();
        }

        public event EventHandler<Alarm> AlarmSet;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SetAlarm();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SetAlarm();
        }
        private void SetAlarm()
        {
            var handler = AlarmSet;
            if (handler != null)
            {
                handler(this, new Alarm { Time = dateTimePicker1.Value, Duration = (int)numericUpDown1.Value });
            }
        }
    }
}

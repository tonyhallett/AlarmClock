using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;

namespace AlarmClock
{
    //[Designer(typeof(SizeBlockerDesigner))]
    public partial class DefaultAlarmView : UserControl,IAlarmView
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
        public bool ShouldSerializeSize()
        {
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }
    }
}

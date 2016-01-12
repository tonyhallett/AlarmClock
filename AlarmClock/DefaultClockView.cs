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
    internal partial class DefaultClockView : UserControl,IClockView
    {
        
        public DefaultClockView()
        {
            InitializeComponent();
        }

        public DateTime Time
        {
            set
            {
                labelTime.Invoke(new Action<DateTime>((val)=>SafeTimeSet(val.ToString())), value);
            }
        }
        private void SafeTimeSet(string time)
        {
            labelTime.Text = time;
        }
    }
}

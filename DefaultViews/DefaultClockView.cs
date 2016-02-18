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

namespace DefaultViews
{
    public partial class DefaultClockView : UserControl,IClockView
    {
        
        public DefaultClockView()
        {
            InitializeComponent();
        }

        public int DoNotSetInTheDesigner
        {
            get; set;
        }

        public DateTime Time
        {
            set
            {
                if (!this.Disposing)
                {
                    labelTime.Invoke(new Action<DateTime>((val) => SafeTimeSet(val.ToString())), value);
                }
            }
        }
        private void SafeTimeSet(string time)
        {
            labelTime.Text = time;
        }
    }
}

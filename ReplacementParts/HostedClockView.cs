
using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Markup;

namespace ReplacementParts
{
    public class HostedClockView:ElementHost,IClockView
    {
        private IWPFClockView wpfClockView;
        //not sure about either - xaml only needed if using it
        //wpfClockView could just know how to get from an embedded resource
        public HostedClockView()
        {
            var wpfClockView = new WPFClockView();
            this.Child = wpfClockView;
            this.wpfClockView = wpfClockView;
            this.AutoSize = true;
            this.SetAutoSizeMode(System.Windows.Forms.AutoSizeMode.GrowAndShrink);
            
        }

        public int DoNotSetInTheDesigner
        {
            get; set;
        }

        public DateTime Time
        {
            set
            {
                wpfClockView.Time = value;
            }
        }
    }
}

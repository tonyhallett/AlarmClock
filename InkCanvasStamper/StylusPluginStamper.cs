using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;

namespace InkCanvasStamper
{
    public class StylusPluginStamper:StylusPlugIn
    {
        private StampedStroke currentStroke;
        public StampedStroke CurrentStroke
        {
            get { return currentStroke; }
        }
        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            currentStroke = new StampedStroke();
            currentStroke.DownStylusPointStamp = DateTime.Now;
            base.OnStylusDown(rawStylusInput);
        }
        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            var movePoint = rawStylusInput.GetStylusPoints()[0];
            var now = DateTime.Now;
            var stamp = (now - currentStroke.DownStylusPointStamp).Ticks;
            currentStroke.StampedStylusPoints.Add(new StampedStylusPoint { Stamp = stamp, StylusPoint = movePoint });
            base.OnStylusMove(rawStylusInput);
        }
    }
    
    public class StampedStroke
    {
        public List<StampedStylusPoint> StampedStylusPoints = new List<StampedStylusPoint>();
        public DateTime DownStylusPointStamp { get; set; }
    }
    public class StampedStylusPoint
    {
        public long Stamp { get; set; }
        public StylusPoint StylusPoint { get; set; }
    }
}

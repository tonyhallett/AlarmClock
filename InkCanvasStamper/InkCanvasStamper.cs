using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;

namespace InkCanvasStamper
{
    public class InkCanvasStamper:InkCanvas
    {
        public event EventHandler<StampedStrokeCollectedEventArgs> StampedStrokeCollected;
        public InkCanvasStamper()
        {
            Stamper = new StylusPluginStamper();
            base.StylusPlugIns.Add(Stamper);
            
        }
        protected override void OnStrokeCollected(InkCanvasStrokeCollectedEventArgs e)
        {
            base.OnStrokeCollected(e);
            var handler = StampedStrokeCollected;
            if (handler != null)
            {
                handler(this, new StampedStrokeCollectedEventArgs { Stroke = e.Stroke, StampedStroke = Stamper.CurrentStroke });
            }
        }
        public StylusPluginStamper Stamper { get; private set; }
    }
    public class StampedStrokeCollectedEventArgs : EventArgs
    {
        public Stroke Stroke { get; set; }
        public StampedStroke StampedStroke { get; set; }
    }
}

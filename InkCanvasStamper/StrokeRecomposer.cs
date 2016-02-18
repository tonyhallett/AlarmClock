using InkCanvasStamper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Threading;

namespace InkCanvasStamper
{
    public class StrokeRecomposer
    {
        private List<Tuple<long, StampedStroke>> stampedStrokes = new List<Tuple<long, StampedStroke>>();
        private int numStampedStrokes;
        private StampedStroke currentStampedStroke;
        private int currentStampedStrokeIndex = -1;
        private Stroke currentStroke;
        
        private int currentPointIndex;
        private InkCanvas inkCanvas;
        private DateTime startTime;
        private DispatcherTimer timer;

        //for debug only
        private bool isDurationRecompose;
        
        private void WriteDetails(string message,List<StampedStroke> stampedStrokes)
        {
            //Console.WriteLine(message);
            //int numPointsToWrite = 3;
            //int pointCount = 0;
            //foreach (var sstr in stampedStrokes)
            //{
            //    Console.WriteLine("Stroke");
            //    Console.WriteLine(sstr.DownStylusPointStamp.ToString());
            //    foreach (var sp in sstr.StampedStylusPoints)
            //    {
            //        Console.WriteLine(sp.Stamp);
            //        pointCount++;
            //        if (pointCount == numPointsToWrite)
            //        {
            //            pointCount = 0;
            //            break;
            //        }
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
        }
        //take in an optional duration ?, drawing attribute
        public StrokeRecomposer(List<StampedStroke> stampedStrokes)
        {
            startTime = stampedStrokes[0].DownStylusPointStamp;
            
            
            foreach(var stampedStroke in stampedStrokes)
            {
                var initialDifference = (stampedStroke.DownStylusPointStamp - startTime).Ticks;
                
                foreach(var stampedStylusPoint in stampedStroke.StampedStylusPoints)
                {
                    var stampDifference = (initialDifference + stampedStylusPoint.Stamp);
                    
                    stampedStylusPoint.Stamp =stampDifference;
                }
                this.stampedStrokes.Add(new Tuple<long, StampedStroke>(initialDifference, stampedStroke));
            }
            
            numStampedStrokes = stampedStrokes.Count;
        }
        //will probably make this multiple canvases
        public void Recompose(InkCanvas inkCanvas)
        {
            this.inkCanvas = inkCanvas;

            timer = new DispatcherTimer();
            CreateStroke();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
       
        private void Timer_Tick(object sender, EventArgs e)
        {
            var elapsed = (DateTime.Now - startTime).Ticks;
            SetCurrentStroke(elapsed);
            if (currentStroke != null)
            {
                var currentStampedStylusPoint = GetCurrentStampedStylusPoint();
                if (elapsed > currentStampedStylusPoint.Stamp)
                {
                    AddCurrentStampedStylusPoint();
                }
            }
        }
        private StampedStylusPoint GetCurrentStampedStylusPoint()
        {
            var current= currentStampedStroke.StampedStylusPoints[currentPointIndex];
            if (currentPointIndex == 0 || currentPointIndex == 1)
            {
                //Console.WriteLine(currentPointIndex.ToString() + ": " + current.Stamp);
            }
            return current;
        }
        private void SetCurrentStroke(long elapsed)
        {
            if (currentStroke == null)
            {
                var stampedStrokeDetails = stampedStrokes[currentStampedStrokeIndex];
                if (elapsed > stampedStrokeDetails.Item1)
                {
                    CreateStroke();
                }
            }
        }
        
        private void CreateStroke()
        {
            currentStampedStrokeIndex++;
            currentStampedStroke = stampedStrokes[currentStampedStrokeIndex].Item2;
            
            var stylusPoints = new StylusPointCollection();
            AddStampedStylusPoint(stylusPoints, currentStampedStroke.StampedStylusPoints[0]);
            currentStroke = new Stroke(stylusPoints);
            inkCanvas.Strokes.Add(currentStroke);
            currentPointIndex = 1;

        }
        private void AddStampedStylusPoint(StylusPointCollection stylusPoints,StampedStylusPoint stampedPoint)
        {
            stylusPoints.Add(new StylusPoint(stampedPoint.StylusPoint.X, stampedPoint.StylusPoint.Y));
        }
        private void AddCurrentStampedStylusPoint()
        {
            var stampedPoint = GetCurrentStampedStylusPoint();
            AddStampedStylusPoint(currentStroke.StylusPoints, stampedPoint);
            currentPointIndex++;
            if (currentPointIndex >= currentStampedStroke.StampedStylusPoints.Count)
            {
                currentStroke = null;
                if (currentStampedStrokeIndex == numStampedStrokes-1)
                {
                    timer.Stop();
                }
            }
        }
    }
}

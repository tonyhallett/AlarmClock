using InkCanvasStamper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using Extensions;

namespace InkRecordAndPlayBack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TimeSpan secondTimespan = new TimeSpan(0, 0, 1);
        private StylusPluginStamper stamper;
        
        private Dictionary<int, List<StampedStroke>> numberStrokes = new Dictionary<int, List<StampedStroke>>();
        private List<int> recordedNumbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public List<int> RecordedNumbers
        {
            get
            {
                return recordedNumbers;
            }
        }
        
        public int SelectedRecordedNumber { get; set; }
        private List<InkCanvas> recomposeCanvases;
        private DispatcherTimer timer;
        private List<StampedStroke> currentStrokes;
        private long drawDuration;
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new DelegateCommand((o) => { Save(); }));
            }
        }
        private void Save()
        {
            XElement root = new XElement("NumberStrokes",

                numberStrokes.Select(ns =>
                {
                    return new XElement("Number", new XAttribute("Number", ns.Key),
                        ns.Value.Select(stroke =>
                        {
                            return new XElement("Stroke", new XAttribute("Stamp", stroke.DownStylusPointStamp), stroke.StampedStylusPoints.Select(sp =>
                             {
                                 return new XElement("StampedStylusPoint",
                                     new XElement("Stamp", sp.Stamp),
                                     new XElement("X", sp.StylusPoint.X),
                                     new XElement("Y", sp.StylusPoint.Y));
                             }));
                        }
                        ));
                })
            );
            root.Save(@"C:\Users\Tony\Documents\StylusPoints\numberStrokes.xml");
        }
        public MainWindow()
        {

            //temp testing
            int hours1 = 8;
            int minutes1 = 45;
            int seconds1 = 23;
            int hours2 = 8;
            int minutes2 = 45;
            int seconds2 = 24;
            DateTime testTime1 = new DateTime(2016, 1, 1, hours1, minutes1, seconds1);
            DateTime testTime2 = new DateTime(2016, 1, 1, hours2, minutes2, seconds2);
            var digits = testTime1.Digits();
            var digits2 = testTime2.Digits();
            var testChange = digits - digits2;

            drawDuration=TimeSpan.FromSeconds(1.1).Ticks;
            var test10SecsTicks = TimeSpan.FromSeconds(10).Ticks;
            InitializeComponent();
            recomposeCanvases = new List<InkCanvas> { recomposeCanvas, recomposeCanvas2, recomposeCanvas3, recomposeCanvas4, recomposeCanvas5, recomposeCanvas6, recomposeCanvas7, recomposeCanvas8, recomposeCanvas9, recomposeCanvas10 };
            stamper = this.inkCanvas.Stamper;
            this.DataContext = this;
            this.inkCanvas.StampedStrokeCollected += InkCanvas_StampedStrokeCollected;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            this.KeyDown += MainWindow_KeyDown;
            this.KeyUp += MainWindow_KeyUp;
        }
        //this is not good and will be moved
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            FinishCurrentStrokes();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            //gets called multiple down
            StartCurrentStrokes();
        }
        private bool isMultiStroke;
        private void FinishCurrentStrokes()
        {
            isMultiStroke = false;
            if (currentStrokes != null)
            {
                FinishStrokes(currentStrokes);
            }
        }
        private void StartCurrentStrokes()
        {
            if (!isMultiStroke)
            {
                currentStrokes = new List<StampedStroke>();
                isMultiStroke = true;
            }
            
        }
        private void FinishStrokes(List<StampedStroke> stampedStrokes)
        {
            List<StampedStroke> existing;
            bool found = numberStrokes.TryGetValue(SelectedRecordedNumber, out existing);
            if (found)
            {
                numberStrokes[SelectedRecordedNumber] = stampedStrokes;
            }
            else
            {
                numberStrokes.Add(SelectedRecordedNumber, stampedStrokes);
            }
            inkCanvas.Strokes.Clear();
            foreach (var de in numberStrokes)
            {
                var number = de.Key;
                if (de.Value.Count > 0)
                {
                    //var toRecomposeCanvas = recomposeCanvases[number];
                    //toRecomposeCanvas.Strokes.Clear();
                    //StrokeRecomposer recomposer = new StrokeRecomposer(de.Value, drawDuration);


                    //recomposer.Recompose(toRecomposeCanvas);
                }
                
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //going to have to deal with single digit
            var now = DateTime.Now;
            var hours = new DateTimeDigits(now.Hour);
            var minutes = new DateTimeDigits(now.Minute);
            var seconds = new DateTimeDigits(now.Second);
            hours1.Strokes.Clear();
            hours2.Strokes.Clear();
            minutes1.Strokes.Clear();
            minutes2.Strokes.Clear();
            seconds1.Strokes.Clear();
            seconds2.Strokes.Clear();
            //may decide not to change if the same 
            ComposeDigits(hours1, hours2, hours);
            ComposeDigits(minutes1, minutes2, minutes);
            ComposeDigits(seconds1, seconds2, seconds);

            
        }
        private void ComposeDigits(InkCanvas firstCanvas,InkCanvas secondCanvas,DateTimeDigits digits)
        {
            List<StampedStroke> firstDigitStampedStrokes;
            numberStrokes.TryGetValue(digits.First, out firstDigitStampedStrokes);
            List<StampedStroke> secondDigitStampedStrokes;
            numberStrokes.TryGetValue(digits.Second, out secondDigitStampedStrokes);
            ComposeDigit(firstCanvas, firstDigitStampedStrokes);
            ComposeDigit(secondCanvas, secondDigitStampedStrokes);
        }
        private void ComposeDigit(InkCanvas canvas,List<StampedStroke> stampedStrokes)
        {
            if (stampedStrokes != null&&stampedStrokes.Count>0)
            {
                var recomposer = new StrokeRecomposer(stampedStrokes);
                recomposer.Recompose(canvas);
            }
        }

        private bool keyDown;
        
        private void InkCanvas_StampedStrokeCollected(object sender,StampedStrokeCollectedEventArgs args)
        {
            var stampedStroke = args.StampedStroke;
            if (isMultiStroke)
            {
                currentStrokes.Add(stampedStroke);
            }
            else
            {
                FinishStrokes(new List<StampedStroke> { stampedStroke });
            }
        }
      
        
    }
    public class DateTimeDigits
    {
        public DateTimeDigits(int hoursOrMinutesOrSeconds)
        {
            int outSecond;
            First= Math.DivRem(hoursOrMinutesOrSeconds, 10, out outSecond);
            Second = outSecond;
        }
        public int First { get; set; }
        public int Second { get; set; }
    }
}

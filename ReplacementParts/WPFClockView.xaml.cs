using InkCanvasStamper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using Extensions;

namespace ReplacementParts
{
    /// <summary>
    /// Interaction logic for WPFClockView.xaml
    /// </summary>
    public partial class WPFClockView : UserControl,IWPFClockView
    {
        private Dictionary<int, List<StampedStroke>> numberStrokes = new Dictionary<int, List<StampedStroke>>();
        private List<InkCanvas> numberCanvases = new List<InkCanvas>();
        private HoursMinutesSecondsChange changeAll = HoursMinutesSecondsChange.HoursFirst | HoursMinutesSecondsChange.HoursSecond | HoursMinutesSecondsChange.MinutesFirst | HoursMinutesSecondsChange.MinutesSecond | HoursMinutesSecondsChange.SecondsFirst | HoursMinutesSecondsChange.SecondsSecond;
        public WPFClockView()
        {
            InitializeComponent();
            numberCanvases.Add(hoursFirst);
            numberCanvases.Add(hoursSecond);
            numberCanvases.Add(minutesFirst);
            numberCanvases.Add(minutesSecond);
            numberCanvases.Add(secondsFirst);
            numberCanvases.Add(secondsSecond);
            var tWidth = this.Width;
            GetStrokes();
        }
        private void GetStrokes()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ReplacementParts.numberStrokes.xml");
            var root = XElement.Load(stream);
            var anonNumberStrokes = root.Elements().Select(nEl =>
            {
                var number = (int)nEl.Attribute("Number");
                var strokes = nEl.Elements().Select(sEl =>
                {
                    var stamp = (DateTime)sEl.Attribute("Stamp");
                    var stampedStylusPoints = sEl.Elements().Select(spEl =>
                    {

                        var stampElement = spEl.Elements("Stamp").FirstOrDefault();
                        long spStamp = long.Parse(stampElement.Value);
                        var xElement = spEl.Elements("X").First();
                        var yElement = spEl.Elements("Y").First();
                        int x = int.Parse(xElement.Value);
                        int y = int.Parse(yElement.Value);
                        return new StampedStylusPoint { Stamp = spStamp, StylusPoint = new StylusPoint { X = x, Y = y } };
                    }).ToList();
                    return new StampedStroke { DownStylusPointStamp = stamp, StampedStylusPoints = stampedStylusPoints };
                }).ToList();
                return new { Number = number, Strokes = strokes };
            });
            foreach (var a in anonNumberStrokes)
            {
                numberStrokes.Add(a.Number, a.Strokes);
            }
        }
        private HoursMinutesSecondsDigits lastDigits;
        public DateTime Time
        {
            set
            {
                var newDigits = value.Digits();
                HoursMinutesSecondsChange change = changeAll;
                if (lastDigits != null)
                {
                    change = newDigits - lastDigits;
                }
                
                if (change != HoursMinutesSecondsChange.None)
                {
                    var index = -1;
                    foreach (HoursMinutesSecondsChange c in Enum.GetValues(typeof(HoursMinutesSecondsChange)))
                    {
                        if (c != HoursMinutesSecondsChange.None)
                        {
                            if (change.HasFlag(c))
                            {
                                var canvas = numberCanvases[index];
                                canvas.Dispatcher.Invoke(() =>
                                {
                                    canvas.Strokes.Clear();
                                    var strokes = numberStrokes[newDigits.GetChangeValue(c)];
                                    StrokeRecomposer recomposer = new StrokeRecomposer(strokes);
                                    recomposer.Recompose(canvas);
                                });
                                
                            }
                        }
                        index++;
                    }
                }
                lastDigits = newDigits;
            }
        }
    }
}

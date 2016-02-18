using System;

namespace Interfaces
{
    public class Alarm
    {
        public int Duration { get; set; }
        public DateTime Time { get; set; }
        public bool Called { get; set; }

    }
}
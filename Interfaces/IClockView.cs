using System;

namespace Interfaces
{
    public interface IClockView
    {
        DateTime Time { set; }
        int DoNotSetInTheDesigner { get; set; }
    }
}
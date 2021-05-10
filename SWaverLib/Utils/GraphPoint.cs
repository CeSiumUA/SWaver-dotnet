using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib.Utils
{
    public struct GraphPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public GraphPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

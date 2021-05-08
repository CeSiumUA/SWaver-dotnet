using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib.SecondLab.BasicParameters
{
    public class ThetaDegrees : MathObject
    {
        public double Radians
        {
            get
            {
                return this.Value * Math.PI / 180;
            }
            set
            {
                var degrees = value * 180 / Math.PI;
                this.Value = degrees;
            }
        }
        public ThetaDegrees(double value, MetricPrefixes prefixes = MetricPrefixes.One, UnitsOfMeasurement unit = UnitsOfMeasurement.Degree) : base(value, prefixes,
            unit)
        {

        }
    }
}

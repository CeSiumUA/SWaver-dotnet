using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib.SecondLab.BasicParameters
{
    public class ThetaDegrees : MathObject
    {
        public ThetaDegrees(double value, MetricPrefixes prefixes = MetricPrefixes.One, UnitsOfMeasurement unit = UnitsOfMeasurement.Degree) : base(value, prefixes,
            unit)
        {

        }
    }
}

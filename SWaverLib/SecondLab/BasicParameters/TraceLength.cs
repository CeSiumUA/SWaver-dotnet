using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib.SecondLab.BasicParameters
{
    public class TraceLength : MathObject
    {
        public TraceLength(double value, MetricPrefixes prefixes = MetricPrefixes.k, UnitsOfMeasurement unit = UnitsOfMeasurement.Meter) : base(value, prefixes, unit)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib.SecondLab.BasicParameters
{
    public class RelativeTraceLength : MathObject
    {
        public RelativeTraceLength(double value, MetricPrefixes prefixes = MetricPrefixes.Percents, UnitsOfMeasurement unit = UnitsOfMeasurement.Percents) : base(value,
            prefixes, unit)
        {

        }
    }
}

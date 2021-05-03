using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib.Utils
{
    public class Height : MathObject
    {
        public Height(double value, MetricPrefixes metricPrefixes = MetricPrefixes.One, UnitsOfMeasurement uom = UnitsOfMeasurement.Meter) : base(value,
            metricPrefixes, uom)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib.Utils
{
    public class Conductivity : MathObject
    {
        public Conductivity(double value, MetricPrefixes prefix = MetricPrefixes.One,
            UnitsOfMeasurement uom = UnitsOfMeasurement.SiemensOnMeter) : base(value, prefix, uom)
        {

        }
    }
}

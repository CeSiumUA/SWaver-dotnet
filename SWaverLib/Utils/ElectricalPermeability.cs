using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib.Utils
{
    public class ElectricalPermeability : MathObject
    {
        public ElectricalPermeability(double value, MetricPrefixes prefix = MetricPrefixes.One,
            UnitsOfMeasurement uom = UnitsOfMeasurement.Units) : base(value, prefix, uom)
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SWaverLib.SecondLab.BasicParameters
{
    public class WaveLength : MathObject
    {
        public WaveLength(double value, MetricPrefixes prefixes = MetricPrefixes.One, UnitsOfMeasurement unit = UnitsOfMeasurement.Meter) : base(value, prefixes, unit)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWaverLib;
using SWaverLib.SecondLab;
using SWaverLib.SecondLab.BasicParameters;

namespace SWaverTests
{
    [TestClass]
    public class SecondLabTest
    {
        public SecondLabTest()
        {

        }

        [TestMethod]
        [DataRow(20, 50, 10, 1, 300)]
        public void CalculateFresnelZone(double waveLength, double traceLength, double relativeTraceLength, int fresnelZoneRadius, double expected)
        {
            WaveLength waveLengthObject = new WaveLength(waveLength, MetricPrefixes.One, UnitsOfMeasurement.Meter);
            TraceLength traceLengthObject = new TraceLength(traceLength);
            RelativeTraceLength relativeTraceLengthObject = new RelativeTraceLength(relativeTraceLength,
                MetricPrefixes.Percents, UnitsOfMeasurement.Percents);
            SecondLabCalculatingObject slco = new SecondLabCalculatingObject(traceLengthObject, waveLengthObject, null,
                relativeTraceLengthObject, null, true, true);
            var nFrenselZone = slco.CalculateNFresnelZone(fresnelZoneRadius).Value;
            Assert.AreEqual(Math.Ceiling(expected), Math.Ceiling(nFrenselZone));
        }
    }
}

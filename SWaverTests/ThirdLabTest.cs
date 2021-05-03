using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWaverLib;
using SWaverLib.SecondLab.BasicParameters;
using SWaverLib.ThirdLab;
using SWaverLib.Utils;

namespace SWaverTests
{
    [TestClass]
    public class ThirdLabTest
    {
        [TestMethod]
        [DataRow(0.001, 25, 20, 150, 150, 90, 1, 20)]
        public void CalculateRelativeElectricalDensity_Test(double conductivity,
            double permeability,
            double waveLength,
            double height1,
            double height2,
            double thetaDegrees,
            double traceLength,
            double expected)
        {
            var thirdLab = new ThirdLabCalculationObject(new Conductivity(conductivity), new ElectricalPermeability(permeability),
                new WaveLength(waveLength), new Height(height1), new Height(height2), new ThetaDegrees(thetaDegrees),
                new TraceLength(traceLength, MetricPrefixes.One));
            var result = thirdLab.CalculateRelativeElectricalDensity();
            Assert.AreEqual(expected, Math.Floor(result.Value));
        }
        [TestMethod]
        [DataRow(0.001, 25, 20, 150, 150, 90, 1, 1)]
        public void CalculateDirectionalFactor_Test(double conductivity,
            double permeability,
            double waveLength,
            double height1,
            double height2,
            double thetaDegrees,
            double traceLength,
            double expected)
        {
            var thirdLab = new ThirdLabCalculationObject(new Conductivity(conductivity), new ElectricalPermeability(permeability),
                new WaveLength(waveLength), new Height(height1), new Height(height2), new ThetaDegrees(thetaDegrees),
                new TraceLength(traceLength, MetricPrefixes.One));
            var result = thirdLab.CalculateDirectionalFactor();
            var roundedResult = Math.Round(result.Value);
            Assert.AreEqual(expected, roundedResult);
        }
    }
}

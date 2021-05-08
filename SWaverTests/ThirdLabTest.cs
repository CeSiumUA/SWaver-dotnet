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
                new TraceLength(traceLength, MetricPrefixes.One), PolarizationType.Horizontal);
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
                new TraceLength(traceLength, MetricPrefixes.One), PolarizationType.Horizontal);
            var result = thirdLab.CalculateDirectionalFactor();
            var roundedResult = Math.Round(result.Value);
            Assert.AreEqual(expected, roundedResult);
        }

        [TestMethod]
        [DataRow(30, 0.5)]
        public void MathSin_Test(double angle, double expectedSin)
        {
            var sin = Math.Round(Math.Sin(angle * Math.PI/180), 1);
            Assert.AreEqual(expectedSin, sin);
        }

        [TestMethod]
        [DataRow(100, 10)]
        [DataRow(-100, Double.NaN)]
        public void NegativeSqrt_Test(double value, double expected)
        {
            var result = Math.Sqrt(value);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [DataRow(0.001, 25, 20, 150, 150, 90, 1, Math.PI/2, (double)2/(double)3, PolarizationType.Horizontal)]
        [DataRow(0.001, 25, 20, 150, 150, 90, 1, 0.1999, 0.92, PolarizationType.Horizontal)]
        [DataRow(0.001, 25, 20, 150, 150, 90, 1, 0, 1, PolarizationType.Horizontal)]

        [DataRow(0.001, 25, 20, 150, 150, 90, 1, Math.PI / 2, (double)2 / (double)3, PolarizationType.Vertical)]
        [DataRow(0.001, 25, 20, 150, 150, 90, 1, 0.1972, 0, PolarizationType.Vertical)]
        [DataRow(0.001, 25, 20, 150, 150, 90, 1, 0, 1, PolarizationType.Vertical)]
        public void CalculateReflectionRatio_Test(double conductivity,
            double permeability,
            double waveLength,
            double height1,
            double height2,
            double thetaDegrees,
            double traceLength,
            double angle,
            double expected,
            PolarizationType polarizationType = PolarizationType.Horizontal)
        {
            var thirdLab = new ThirdLabCalculationObject(new Conductivity(conductivity), new ElectricalPermeability(permeability),
                new WaveLength(waveLength), new Height(height1), new Height(height2), new ThetaDegrees(thetaDegrees),
                new TraceLength(traceLength, MetricPrefixes.One), polarizationType);
            var result = thirdLab.CalculateReflectionCoefficientByAngle(
                new ThetaDegrees(angle, MetricPrefixes.One, UnitsOfMeasurement.Degree)
                {
                    Radians = angle
                });
            Assert.AreEqual(Math.Round(expected, 2), Math.Round(result, 2));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWaverLib;

namespace SWaverTests
{
    [TestClass]
    public class LabTest
    {
        [TestMethod]
        public void FadingCalculatorTest()
        {
            var fading = FiderCalculation.FiderExtinction(10, 1);
            Assert.AreEqual(0.1, fading);
        }
        [TestMethod]
        [DataRow(100, MetricPrefixes.M, UnitsOfMeasurement.Meter, 100000000)]
        public void TransformToSystemInternational_Test(double value, MetricPrefixes prefix, UnitsOfMeasurement uom, double expectedValue)
        {
            MathObject mathObject = new MathObject(value, prefix, uom);
            var rawValue = mathObject.TransformToSystemInternational();
            Assert.AreEqual(expectedValue, rawValue);
        }
    }
}

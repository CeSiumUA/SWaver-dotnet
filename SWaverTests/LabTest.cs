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
        public void TransformToSystemInternational_Test()
        {
            MathObject mathObject = new MathObject(100, MetricPrefixes.k, UnitsOfMeasurement.Meter);
            var rawValue = mathObject.TransformToSystemInternational();
            Assert.AreEqual(rawValue, 100000);
        }
    }
}

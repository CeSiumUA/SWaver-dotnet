using NUnit.Framework;
using SWaverLib;

namespace SWaverTests
{
    public class Tests
    {
        private double frequency;
        private double transmitterPower;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var fading = FiderCalculation.FiderExtinction(10, 1);
            Assert.AreEqual(0.1, fading);
        }

        [Test]
        public void TransformToSystemInternational_Test()
        {
            MathObject mathObject = new MathObject(100, MetricPrefixes.k, UnitsOfMeasurement.Meter);
            var rawValue = mathObject.TransformToSystemInternational();
            Assert.AreEqual(rawValue, 100000);
        }
    }
}
using NUnit.Framework;
using SWaverLib;

namespace SWaverTests
{
    public class Tests
    {
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
    }
}
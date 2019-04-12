using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new DemeritPointsCalculator();
        }

        [Test]
        public void CalculateDemeritPoints_SpeedUnderZero_ThrowArgumentOutOfRangeException()
        {
            int underZero = -1;
            Assert.That(() => calculator.CalculateDemeritPoints(underZero),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_SpeedOverMaxSpeed_ThrowArgumentOutOfRangeException()
        {
            int overMaxSpeed = 301;
            Assert.That(() => calculator.CalculateDemeritPoints(overMaxSpeed),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0)]
        [TestCase(65)]
        public void CalculateDemeritPoints_SpeedBelowSpeedLimit_ThrowArgumentOutOfRangeException(int speed)
        {
            int demeritPoint = 0;
            var result = calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(demeritPoint));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedOverMinimumLimit_ReturnDemiritPoints()
        {

            int speed = 66;
            var result = calculator.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedOverMaximumLimit_ReturnDemiritPoints()
        {

            int speed = 300;
            var result = calculator.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(47));
        }

    }
}

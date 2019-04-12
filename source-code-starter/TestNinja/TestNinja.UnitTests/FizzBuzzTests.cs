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
    public class FizzBuzzTests
    {
        

        [Test]
        public void GetOutPut_MinusMultipleOf3And5_ReturnFizzBuss()
        {
            var result = FizzBuzz.GetOutput(-15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutPut_MinusMultipleOf3_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(-6);
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutPut_MinusMultipleOf5_ReturnBuss()
        {
            var result = FizzBuzz.GetOutput(-10);
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutPut_MinusNaturalNumber_ReturnNumber()
        {
            var result = FizzBuzz.GetOutput(-4);
            Assert.That(result, Is.EqualTo((-4).ToString()));
        }

        [Test]
        public void GetOutPut_MultipleOf3And5_ReturnFizzBuss()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutPut_MultipleOf3_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(6);
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutPut_MultipleOf5_ReturnBuss()
        {
            var result = FizzBuzz.GetOutput(10);
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutPut_NaturalNumber_ReturnNumber()
        {
            var result = FizzBuzz.GetOutput(4);
            Assert.That(result, Is.EqualTo(4.ToString()));
        }

        [Test]
        public void GetOutPut_DividedByZero_ReturnZero()
        {
            Assert.That(() => FizzBuzz.GetOutput(0), Throws.Exception.TypeOf<DivideByZeroException>());
        }
    }
}

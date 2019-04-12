using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;
        // setup
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSomOfTwoArguments()
        {
            var result = _math.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentIsBiggerThanSecondOne_ReturnTheFirstArgument()
        {
            var result = _math.Max(2, 1);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var math = new Math();
            var result = math.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [Ignore("To test Ignoring Test")]
        public void Max_TwoArgumentIsEqual_ReturnTheSameArgument()
        {
            var result = _math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }

        // parameterized test
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        // trustworthy
        // code >> test >> change code >> test again
        [Test]
        public void MaxWrong()
        {
            var result = _math.MaxWrong(2, 1);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            Assert.That(result, Is.EquivalentTo(new[] {1, 3, 5}));
        }

        [Test]
        public void GetOddNumbers_CheckEmptyOrNot_ReturnOrderedOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GetOddNumbers_CheckOrdered_ReturnOrderedOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            Assert.That(result, Is.Ordered);
        }

        [Test]
        public void GetOddNumbers_CheckItemsAreUniqueInEnumerable_ReturnOrderedOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            Assert.That(result, Is.Unique);
        }
    }
}

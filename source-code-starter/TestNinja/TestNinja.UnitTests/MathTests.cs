
using System.Linq;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        // SetUp : 멤버변수를 각각의 테스트를 위하여 초기화하거나 하는데 많이 쓴다
        private Math _math;

        // TearDown : 보통 integration test에서 많이 한다

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var math = new Math();       // 각각의 케이스마다 클래스를 만들어주는 것이 좋다??
            var result = math.Add(1, 2); // 멤버변수로 만들어 재사용 할 경우 오염될 수 있다
                                         // 근데 그럴 수 없을 경우에는 setup과 teardown을 한다
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var result = _math.Max(2, 1); // Setup을 통하여 매번 초기화한다

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var result = _math.Max(1, 2); // Setup을 통하여 매번 초기화한다

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            var result = _math.Max(1, 1); // Setup을 통하여 매번 초기화한다

            Assert.That(result, Is.EqualTo(1));
        }

        /*
        # Parameterized Tests
         - 위의 테스트는 동일한 테스트이나 매개변수만 다르다
         - 이러한 경우 매개변수를 받아 코드를 줄일 수 있다
         */
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Add_WhenCalled_ReturnTheGreaterArguments(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /*
        # Lec24. Ignoring Tests
         - 만약 오래걸리는 테스트의 경우 ignore 할 수 있다
         - 노란색 경보 아이콘으로 표시된다
        */
        [Test]
        [Ignore("Because I wanted to!")] // 매개변수는 이유이다
        public void Max_ArgumentsAreEqual2_ReturnTheSameArgument()
        {
            var result = _math.Max(1, 1); // Setup을 통하여 매번 초기화한다

            Assert.That(result, Is.EqualTo(1));
        }

        /*
        # Lec25. Writing Trustworthy Tests
         - 신뢰할수 있는 코드 작성법
         - TDD
         - Code first의 상황이라면,
           1. 코드를 작성하고
           2. 테스트 케이스를 작성하여 테스트한다
           3. 성공한다면 다시 코드로 가서 버그가 생길 상황으로 값을 바꾸어본다
        */

        [Test]
        public void AddWrong_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            var result = _math.AddWrong(1, 2);

            //Assert.That(result, Is.EqualTo(3)); // // 정상적으로 테스트가 이루어진 케이스이다

            Assert.That(result, Is.Not.Null); // 언제나 pass한다, 잘못된 케이스, 잘못된것을 테스트한다
                                              // not trustworthy
        }

        /* Lec30. Testing Arrays and Collections */
        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            /*
            // 1. check it is not empty
            Assert.That(result, Is.Not.Empty);

            // 2. result count
            Assert.That(result.Count(), Is.EqualTo(3));

            // 3. check items wihtout order
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));

            */
            // 3-1. 순서대로 체크
            Assert.That(result, Is.EquivalentTo(new[] {1, 3, 5})); // don't care about the order
                                                                   // just check the item is or not

            // 4. 기타 체크
            Assert.That(result, Is.Ordered); // 순서대로 되어 있는지
            Assert.That(result, Is.Unique); // 각각의 아이템이 unique한지 체크
        }
    }
}

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
    public class ErrorLoggerTests
    {
        /*
        # Lec32.Testing Void Methods
        */

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a");

            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        /*
        # Lec33.Testing Methods that Throw Exceptionis
         - 델리게이트로 만들어서 비교
        */

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArugmentNullException(string error)
        {
            var logger = new ErrorLogger();

            // logger.Log(error); // 이대로는 Exception으로 터진다 delegate로 감싸줘야한다

            // 2가지 방식으로 할 수 있는데 첫번째껏이 더 깔끔
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
            //Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>());
        }

        /*
        # Lec34.Testing Methods that Raise an Event
         - 이벤트 핸들러를 등록하여 그 값을 비교한다
        */
        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };
            logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        /*
        # Lec35. Testing private methods
         - Shouldn't test private or protected methods
         - 내부의 로직은 바뀔 수 있다 하지만 public 동작은 항상 일정하게 유지하게하는게 목적
         - 만약 public 클래스 내부에 너무 많은 private 클래스가 있다면 리팩토링 및 분리 필요
        */
        [Test]
        public void LogForProtectedMethod_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.ErrorLoggedForPrivateMethod += (sender, args) => { id = args; };
            logger.LogForProtectedMethod("a"); // 테스트가 통과한다

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void OnErrorLogged_WhenCalled_RaiseEvent()
        {
            var logger = new ErrorLogger();
            //logger.OnErrorLogged(Guid.NewGuid()); // 이처럼 리팩토링 할 때에 public이 아닌 메소드를 테스트하려하면 잘 터진다

            Assert.That(true);
        }
    }
}

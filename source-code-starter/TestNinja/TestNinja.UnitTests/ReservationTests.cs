using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    /* NUnit Test */
    [TestFixture]
    public class ReservationTests
    {
        /*
        # 테스트명은 3파트로 나뉜다
         1. 메서드명
         2. 시나리오
         3. 예상되는 동작
        */
        [Test] // 모든 테스트는 public void라야 한다
        public void CanBeCancelledBy_Scenario_ExpectedBehavior() // 테스트 네이밍 이런 식으로
        {
            // 내용은 3부분으로 나뉜다(Triple A)
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue() 
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User {IsAdmin = true});

            // Assert
            //Assert.IsTrue(result);
            Assert.That(result, Is.True); // 3개다 동일한 의미를 가지지만 가장 영어 문법흐름에 맞다
            //Assert.That(result == true); 
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnTrue()
        {
            var user = new User();
            var reservation = new Reservation(){ MadeBy = user};

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnFalse()
        {
            var reservation = new Reservation(){MadeBy = new User()};

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }

    

    /* MSTest */
    /*
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnTrue()
        {
            var user = new User();
            var reservation = new Reservation() { MadeBy = user };

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnFalse()
        {
            var reservation = new Reservation() { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }

    */
}

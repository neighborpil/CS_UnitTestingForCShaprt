using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelled_UserIsAdamin_ReturnTrue()
        {
            var reservation = new Reservation();
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelled_SameUserCancellingTheReservation_ReturnTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user };
            var result = reservation.CanBeCancelledBy(user);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelled_AnotherUserCancellingTheReservation_ReturnFalse()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user };
            var result = reservation.CanBeCancelledBy(new User());

            Assert.That(result, Is.False);
        }
    }
}

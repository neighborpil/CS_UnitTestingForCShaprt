using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IBookingStorage
    {
        IQueryable<Booking> Query(Booking booking);
    }

    public class BookingStorage : IBookingStorage
    {
        UnitOfWork unitOfWork;

        public BookingStorage()
        {
            unitOfWork = new UnitOfWork();
        }

        public IQueryable<Booking> Query(Booking booking)
        {
            return unitOfWork.Query<Booking>().Where(
                b => b.Id != booking.Id && b.Status != "Cancelled"); ;
        }

    }
}

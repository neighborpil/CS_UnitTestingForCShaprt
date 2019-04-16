using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IBookRepository
    {
        IQueryable<Booking> GetActivieBooking(int? excludedBookingId = null);
    }

    public class BookRepository : IBookRepository
    {
        private readonly UnitOfWork unitOfWork;

        public BookRepository()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public IQueryable<Booking> GetActivieBooking(int? excludedBookingId = null)
        {
            var bookings = unitOfWork.Query<Booking>()
                .Where(b => b.Status != "Cancelled");

            if (excludedBookingId.HasValue)
                bookings.Where(b => b.Id != excludedBookingId.Value);
            return bookings;
        }
    }
}

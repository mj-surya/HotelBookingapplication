using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Contexts;
using HotelBookingApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApplication.Repositories
{
    public class BookingRepository : IRepository<int, Booking>
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }
        public Booking Add(Booking entity)
        {
            _context.Bookings.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Booking Delete(int key)
        {
            throw new NotImplementedException();
        }
 
        public IList<Booking> GetAll()
        {
            if (_context.Bookings.Count() == 0)
                return null;

            return _context.Bookings.ToList();
        }

        public Booking GetById(int key)
        {
            var booking = _context.Bookings.SingleOrDefault(u => u.BookingId == key);
            return booking;
        }

        public Booking Update(Booking entity)
        {
            var booking = GetById(entity.BookingId);
            if (booking != null)
            {
                _context.Entry<Booking>(booking).State = EntityState.Modified;
                _context.SaveChanges();
                return booking;
            }
            return null;
        }
    }
}

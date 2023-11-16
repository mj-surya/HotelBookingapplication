using HotelBookingApplication.Contexts;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApplication.Repositories
{
    public class ReviewRepository : IRepository<int, Review>
    {
        private readonly BookingContext _context;
        public ReviewRepository(BookingContext context)
        {
            _context = context;
        }
        public Review Add(Review entity)
        {
            _context.Reviews.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Review Delete(int key)
        {
            var review = GetById(key);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
                return review;
            }
            return null;
        }

        public IList<Review> GetAll()
        {
            if (_context.Reviews.Count() == 0)
                return null;
            return _context.Reviews.ToList();
        }

        public Review GetById(int key)
        {
            var review = _context.Reviews.SingleOrDefault(u => u.ReviewId == key);
            return review;
        }

        public Review Update(Review entity)
        {
            var review = GetById(entity.ReviewId);
            if (review != null)
            {
                _context.Entry<Review>(review).State = EntityState.Modified;
                _context.SaveChanges();
                return review;
            }
            return null;
        }
    }
}

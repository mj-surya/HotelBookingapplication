using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<int, Review> _reviewrepository;
        public ReviewService (IRepository<int, Review> reviewRepository)
        {
            _reviewrepository = reviewRepository;
        }
        public ReviewDTO AddReview(ReviewDTO reviewDTO)
        {
            Review review = new Review()
            {
                UserId = reviewDTO.UserId,
                HotelId = reviewDTO.HotelId,
                Reviews = reviewDTO.Reviews,
                Rating = reviewDTO.Rating,
                Date = reviewDTO.Date
            };
            var result = _reviewrepository.Add(review);
            if (result != null)
            {
                return reviewDTO;
            }
            return null;
        }

        public bool DeleteReview(int id)
        {
            var reviewcheck = _reviewrepository.Delete(id);
            if (reviewcheck != null)
            {
                return true;
            }
            return false;
        }

        public List<Review> GetReviews(int hotelId)
        {
            var review = _reviewrepository.GetAll().Where(r => r.HotelId==hotelId).ToList();
            if (review.Count != 0)
            {
                return review.ToList();
            }
            throw new NoReviewAvailableException();
        }

        public ReviewDTO UpdateReview(int id, ReviewDTO reviewDTO)
        {
            var review = _reviewrepository.GetById(id);
            if (review != null)
            {
                review.HotelId = reviewDTO.HotelId;
                review.UserId = reviewDTO.UserId;
                review.Reviews = reviewDTO.Reviews;
                review.Rating = reviewDTO.Rating;
                review.Date = reviewDTO.Date;
                var result = _reviewrepository.Update(review);
                return reviewDTO;
            }
            return null;
        }
    }
}

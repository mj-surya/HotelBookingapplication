using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Interfaces
{
    public interface IReviewService
    {
        ReviewDTO AddReview(ReviewDTO reviewDTO);
        ReviewDTO UpdateReview(int id,ReviewDTO reviewDTO);
        bool DeleteReview(int id);
        List<Review> GetReviews(int hotelId);

    }
}

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
        /// <summary>
        /// Add the review based on the provided reviewDTO
        /// </summary>
        /// <param name="reviewDTO">ReviewDTO contains detail of review</param>
        /// <returns>Return the reviewDTO if the review is added successfully; Otherwise return null</returns>
        public ReviewDTO AddReview(ReviewDTO reviewDTO)
        {
            //Create a new review object with details provided by the reviewDTO
            Review review = new Review()
            {
                UserId = reviewDTO.UserId,
                HotelId = reviewDTO.HotelId,
                Reviews = reviewDTO.Reviews,
                Rating = reviewDTO.Rating,
                Date = reviewDTO.Date
            };
            
            //Add the review to the repository
            var result = _reviewrepository.Add(review);

            //Check if the review added succesfully return reviewDTO; Otherwise return null
            if (result != null)
            {
                return reviewDTO;
            }
            return null;
        }

        /// <summary>
        /// Delete the review based on the unique reviewId
        /// </summary>
        /// <param name="id">The unique identifier of a review</param>
        /// <returns>Return true if review deleted; Otherwise return false</returns>
        public bool DeleteReview(int id)
        {
            //Dlete the review based on the specified id from the repository
            var reviewcheck = _reviewrepository.Delete(id);

            //Check if the review is deleted, return true if review deleted sucessfully;  Otherwise return false
            if (reviewcheck != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retrieve the list of review object based on the hotelID
        /// </summary>
        /// <param name="hotelId">The unique identifier of hotel</param>
        /// <returns>Return the review object based on hotelId</returns>
        /// <exception cref="NoReviewAvailableException">throw No reviews are available for display</exception>
        public List<Review> GetReviews(int hotelId)
        {

            //Retrieve the review based on the specified hotelId
            var review = _reviewrepository.GetAll().Where(r => r.HotelId==hotelId).ToList();

            //Check if review is found and return review; Otherwise throw new NoReviewAvailableException
            if (review.Count != 0)
            {
                return review.ToList();
            }
            throw new NoReviewAvailableException();
        }

        /// <summary>
        /// Update the review based on the specified id and the reviewDTO
        /// </summary>
        /// <param name="id">The unique identifier of a review</param>
        /// <param name="reviewDTO">ReviewDTO contains updated detail of review</param>
        /// <returns>Return the reviewDTO if successfully updated; Otherwise return null</returns>
        public ReviewDTO UpdateReview(int id, ReviewDTO reviewDTO)
        {
            //Retrieve the review object based on the provided id from the repository
            var review = _reviewrepository.GetById(id);

            //Check if the review is found
            if (review != null)
            {
                //Update the review details provided by the reviewDTO
                review.HotelId = reviewDTO.HotelId;
                review.UserId = reviewDTO.UserId;
                review.Reviews = reviewDTO.Reviews;
                review.Rating = reviewDTO.Rating;
                review.Date = reviewDTO.Date;

                //Update the review in the repository
                var result = _reviewrepository.Update(review);

                //Return the reviewDTO
                return reviewDTO;
            }
            //Return null if review was not updated
            return null;
        }
    }
}

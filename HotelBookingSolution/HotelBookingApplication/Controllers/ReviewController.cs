using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly ILogger _logger;
        public ReviewController(IReviewService reviewService, ILogger<ReviewController> logger)
        {
            _reviewService = reviewService;
            _logger = logger;
        }
        /// <summary>
        /// Add the review of a hotel
        /// </summary>
        /// <param name="reviewDTO">Review details</param>
        /// <returns>review added message</returns>
        [HttpPost("AddReview")]
        [Authorize(Roles = "User")]
        public ActionResult AddReview(ReviewDTO reviewDTO)
        {
            var review = _reviewService.AddReview(reviewDTO);
            if (review != null)
            {
                _logger.LogInformation("Review Added");
                return Ok(review);
            }
            _logger.LogError("Could not add review");
            return BadRequest("Could not add rooms");
        }
        /// <summary>
        /// Remove the review
        /// </summary>
        /// <param name="id">review id</param>
        /// <returns>Display deleted message</returns>
        [HttpPost("DeleteReview")]
        [Authorize(Roles = "User")]
        public ActionResult DeleteReviews(int id)
        {
            bool reviewId = _reviewService.DeleteReview(id);
            if (reviewId)
            {
                _logger.LogInformation("Review Deleted");
                return Ok("The review has been deleted successfully");

            }
            _logger.LogError("Unable to delete review");
            return BadRequest("Invalid reviewId");
        }
        /// <summary>
        /// Update the review
        /// </summary>
        /// <param name="id">review id</param>
        /// <param name="reviewDTO">datails of review</param>
        /// <returns></returns>
        [HttpPost("UpdateReview")]
        [Authorize(Roles = "User")]
        public ActionResult UpdateReview(int id, ReviewDTO reviewDTO)
        {
            var review = _reviewService.UpdateReview(id, reviewDTO);
            if (review != null)
            {
                _logger.LogInformation("Review Updated");
                return Ok("Review updated successfully");

            }
            _logger.LogError("Unable to update review");
            return BadRequest("Unable to update reivew");
        }
        /// <summary>
        /// Get the review of hotel
        /// </summary>
        /// <param name="hotelId">id of hotel</param>
        /// <returns>display the review of hotel</returns>
        [HttpPost("GetReview")]
        public ActionResult GetAvailableReviews(int hotelId)
        {
            string errorMessage = "";
            try
            {
                var result = _reviewService.GetReviews(hotelId);
                if (result != null)
                {
                    _logger.LogInformation("Reviews Displayed");
                    return Ok(result);

                }
            }
            catch (NoReviewAvailableException e)
            {
                errorMessage = e.Message;
            }
            _logger.LogError("Unable to display reviews");
            return BadRequest(errorMessage);

        }
    }
}

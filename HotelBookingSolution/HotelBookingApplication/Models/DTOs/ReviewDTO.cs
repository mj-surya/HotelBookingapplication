using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models.DTOs
{
    public class ReviewDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user submitting the review.
        /// </summary>
        [Required(ErrorMessage = "User Id cannot be empty")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the hotel being reviewed.
        /// </summary>
        [Required(ErrorMessage = "Hotel Id cannot be empty")]
        public int HotelId { get; set; }

        /// <summary>
        /// Gets or sets the review text provided by the user.
        /// </summary>
        [Required(ErrorMessage = "Review cannot be empty")]
        public string Reviews { get; set; }

        /// <summary>
        /// Gets or sets the rating given by the user for the hotel.
        /// </summary>
        [Required(ErrorMessage = "Rating cannot be empty")]
        public string Rating { get; set; }
        [Required(ErrorMessage = "Date cannot be empty")]

        /// <summary>
        /// Gets or sets the date when the review was submitted.
        /// </summary>
        public string Date { get; set; }
    }
}

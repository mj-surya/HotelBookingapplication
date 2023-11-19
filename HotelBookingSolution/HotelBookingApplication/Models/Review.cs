using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Review
    {
        /// <summary>
        /// Gets or sets the unique identifier of the review
        /// </summary>
        [Key]
        public int ReviewId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier associated with the reviw
        /// </summary>
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }

        /// <summary>
        /// Gets or sets the hotel identifier associated with the review
        /// </summary>
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel hotel { get; set; }

        /// <summary>
        /// Gets or sets the text provioded by the user
        /// </summary>
        public string Reviews { get; set; }

        /// <summary>
        /// Gets or sets the rating given by the user for the hotel
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the date when the review was submitted 
        /// </summary>
        public string Date { get; set; }
    }
}
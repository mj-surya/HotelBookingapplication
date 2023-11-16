using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models.DTOs
{
    public class ReviewDTO
    {
        [Required(ErrorMessage = "User Id cannot be empty")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Hotel Id cannot be empty")]
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Review cannot be empty")]
        public string Reviews { get; set; }
        [Required(ErrorMessage = "Rating cannot be empty")]
        public string Rating { get; set; }
        [Required(ErrorMessage = "Date cannot be empty")]
        public string Date { get; set; }
    }
}

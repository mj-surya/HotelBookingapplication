using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
        public int HotelId { get; set; }
        public Hotel hotel { get; set; }
        public string Reviews { get; set; }
        public string Rating { get; set; }
        public string Date { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Review
    {
        [Key]
        public int ReviewId{ get; set; }
        public string Email { get; set; }
        public string HotelId { get; set; }
        public string Reviews { get; set; }
        public string Rating { get; set; }
        public string Date { get; set; }
    }
}

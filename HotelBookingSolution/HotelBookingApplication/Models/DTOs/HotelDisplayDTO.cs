using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class HotelDisplayDTO
    {
        public int HotelId { get; set; }
        public string UserId { get; set; }
        public string HotelName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public float StartingPrice { get; set; } = 0;
        public string Image { get; set; }
        public float AvgRating { get; set; } = 0;
    }
}

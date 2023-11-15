using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string  HotelName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}

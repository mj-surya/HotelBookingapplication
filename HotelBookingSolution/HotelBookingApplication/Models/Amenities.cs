using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Amenities
    {
        [ForeignKey("HotelId")]
        public int HotelId { get; set; }
        public string Amenity{ get; set; }
    }
}

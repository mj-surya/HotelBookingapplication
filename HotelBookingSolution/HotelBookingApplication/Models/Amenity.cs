using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Amenity
    {
        [ForeignKey("HotelId")]
        public int HotelId { get; set; }
        public string Amenities{ get; set; }
    }
}

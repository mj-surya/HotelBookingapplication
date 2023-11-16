using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Amenity
    { 
        [Key]
        public int AmenityId { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel hotel { get; set; }
        public string Amenities { get; set; }
    }
}

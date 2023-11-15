using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Amenity
    { 
        [Key]
        public int AmenityId { get; set; }
        [ForeignKey("HotelId")]
        public int HotelId { get; set; }
        public string Amenities { get; set; }
    }
}

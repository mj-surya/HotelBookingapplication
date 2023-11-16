using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class RoomAmenity
    {
        [Key]
        public int RoomAmenityId { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room room { get; set; }
        public string Amenities { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Images
    {
        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        public string Image { get; set; }
    }
}

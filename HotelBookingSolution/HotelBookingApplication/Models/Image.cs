using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Image
    {
        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        public string Picture { get; set; }
    }
}

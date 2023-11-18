using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
        public string BookingDate { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room room { get; set; }
        public string Status { get; set; }
        public int TotalRoom { get; set; }
        public float? Price { get; set; }
    }
}

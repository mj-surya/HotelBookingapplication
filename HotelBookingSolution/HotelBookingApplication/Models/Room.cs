using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public string HotelId { get; set; }
        public float Price { get; set; }
        public string Capacity { get; set; }
        public string TotalRooms { get; set; }
        public string Description { get; set; }
    }
}
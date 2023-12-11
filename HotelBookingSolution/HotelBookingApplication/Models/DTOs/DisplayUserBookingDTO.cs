using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models.DTOs
{
    public class DisplayUserBookingDTO
    {
        public int BookingId { get; set; } = 0;
        public string UserId { get; set; } = "";
        public string BookingDate { get; set; } = "";
        public string CheckIn { get; set; } = "";
        public string CheckOut { get; set; } = "";
        public int RoomId { get; set; }= 0;
        public string Status { get; set; } = "";
        public int TotalRoom { get; set; } = 0;
        public float Price { get; set; } = 0;  
        public string Payment { get; set; } = "";
        public string? HotelName { get; set; }
        public string RoomType { get; set; } = "";
    }
}

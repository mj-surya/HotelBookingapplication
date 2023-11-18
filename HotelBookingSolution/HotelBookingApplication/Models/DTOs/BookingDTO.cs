using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models.DTOs
{
    public class BookingDTO
    {
        public String UserId { get; set; }
       
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public int RoomId { get; set; }
        
        public int TotalRoom { get; set; }

    }
}

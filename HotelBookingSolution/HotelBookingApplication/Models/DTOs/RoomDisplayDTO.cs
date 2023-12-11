using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models.DTOs
{
    public class RoomDisplayDTO
    {
        public int RoomId { get; set; } = 0;

        public string RoomType { get; set; } = "";

        public int HotelId { get; set; } = 0;


        public string Picture { get; set; } = "";

        public float Price { get; set; } = 0;

        public int Capacity { get; set; } = 0;

        public int TotalRooms { get; set; } = 0;

        public string Description { get; set; } = "";
        public List<string> Amenities { get; set; } = new List<string>();   
    }
}

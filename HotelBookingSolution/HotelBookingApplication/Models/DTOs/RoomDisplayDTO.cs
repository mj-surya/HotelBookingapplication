using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models.DTOs
{
    public class RoomDisplayDTO
    {
        public int RoomId { get; set; }

        public string RoomType { get; set; }

        public int HotelId { get; set; }


        public string Picture { get; set; }

        public float Price { get; set; }

        public int Capacity { get; set; }

        public int TotalRooms { get; set; }

        public string Description { get; set; }
        public List<string> Amenities { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models.DTOs
{
    public class RoomDTO
    {
        [Required(ErrorMessage = "Room type cannot be empty")]
        public string RoomType { get; set; }
        [Required(ErrorMessage = "Hotel ID cannot be empty")]
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Price cannot be empty")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Capacity cannot be empty")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Available room cannot be empty")]
        public int TotalRooms { get; set; }
        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Images cannot be empty")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Amenities cannot be empty")]
        public List<string> roomAmenities { get; set; }

    }
}

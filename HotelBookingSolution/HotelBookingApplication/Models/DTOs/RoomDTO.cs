using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models.DTOs
{
    public class RoomDTO
    {
        [Required(ErrorMessage = "Room type cannot be empty")]
        public string RoomType { get; set; }

        [Required(ErrorMessage = "Price cannot be empty")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Capacity cannot be empty")]
        public string Capacity { get; set; }
        [Required(ErrorMessage = "Available room cannot be empty")]
        public string TotalRooms { get; set; }
        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }

    }
}

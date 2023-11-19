using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models.DTOs
{
    public class RoomDTO
    {

        /// <summary>
        /// Gets or sets the type of the room.
        /// </summary>
        [Required(ErrorMessage = "Room type cannot be empty")]
        public string RoomType { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the hotel to which the room belongs.
        /// </summary>
        [Required(ErrorMessage = "Hotel ID cannot be empty")]
        public int HotelId { get; set; }

        /// <summary>
        /// Gets or sets the price of the room.
        /// </summary>
        [Required(ErrorMessage = "Price cannot be empty")]
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets the number of occupants for the room.
        /// </summary>
        [Required(ErrorMessage = "Capacity cannot be empty")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Available room cannot be empty")]

        /// <summary>
        /// Gets or sets the total number of available rooms.
        /// </summary>
        public int TotalRooms { get; set; }

        /// <summary>
        /// Gets or sets the description of the room.
        /// </summary>
        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the path to the image representing the room.
        /// </summary>
        [Required(ErrorMessage = "Images cannot be empty")]
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets the list of amenities available in the room.
        /// </summary>
        [Required(ErrorMessage = "Amenities cannot be empty")]
        public List<string> roomAmenities { get; set; }

    }
}

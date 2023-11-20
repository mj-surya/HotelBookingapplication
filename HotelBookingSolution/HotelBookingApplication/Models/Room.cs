using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Room
    {
        /// <summary>
        /// Gets or sets the unique identifier of a room
        /// </summary>
        [Key]
        public int RoomId { get; set; }

        /// <summary>
        /// gets or sets the type of room
        /// </summary>
        public string RoomType { get; set; }

        /// <summary>
        /// Gets or sets the hotel identifier associated with the room
        /// </summary>
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel hotel { get; set; }

        /// <summary>
        /// Gets or sets the path of image representing the room
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets price of room based on the room type
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets the occupants of the room
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or sets the total room of available room
        /// </summary>
        public int TotalRooms { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
    }
}
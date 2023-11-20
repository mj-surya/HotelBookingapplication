using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class RoomAmenity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the amenity
        /// </summary>
        [Key]
        public int RoomAmenityId { get; set; }

        /// <summary>
        /// Gets or sets the unique room identifier associated with room amenity
        /// </summary>
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room room { get; set; }

        /// <summary>
        /// Gets or sets the amenities for the room
        /// </summary>
        public string Amenities { get; set; }
    }
}

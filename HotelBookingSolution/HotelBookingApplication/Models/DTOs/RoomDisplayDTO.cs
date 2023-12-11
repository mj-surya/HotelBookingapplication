using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models.DTOs
{
    public class RoomDisplayDTO
    {
        /// <summary>
        /// Gets and sets roomId
        /// </summary>
        public int RoomId { get; set; } = 0;
        /// <summary>
        /// Gets and sets RoomType
        /// </summary>
        public string RoomType { get; set; } = "";
        /// <summary>
        /// Gets and sets HotelID
        /// </summary>

        public int HotelId { get; set; }= 0;
        /// <summary>
        /// Gets and sets the room picture
        /// </summary>

        public string Picture { get; set; } = "";
        /// <summary>
        /// Gets and sets room's price
        /// </summary>
        public float Price { get; set; } = 0;
        /// <summary>
        /// Gets and sets room's capacity
        /// </summary>
        public int Capacity { get; set; } = 0;
        /// <summary>
        /// Gets and sets the total rooms
        /// </summary>
        public int TotalRooms { get; set; } = 0;
        /// <summary>
        /// Gets and sets rooms description
        /// </summary>
        public string Description { get; set; } = "";
        /// <summary>
        /// Gets and sets room amenities list
        /// </summary>
        public List<string> Amenities { get; set; }= new List<string>();

    }
}

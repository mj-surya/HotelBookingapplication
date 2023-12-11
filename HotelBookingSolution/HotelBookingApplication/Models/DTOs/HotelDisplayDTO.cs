using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class HotelDisplayDTO
    {
        /// <summary>
        /// Gets and sets hotelID
        /// </summary>
        public int HotelId { get; set; } = 0;
        /// <summary>
        /// Gets and sets UserID
        /// </summary>
        public string UserId { get; set; } = "";
        /// <summary>
        /// Gets and sets Hotel Name
        /// </summary>
        public string HotelName { get; set; } = "";
        /// <summary>
        /// Gets and sets hotel's city
        /// </summary>
        public string City { get; set; } = "";
        /// <summary>
        /// Gets and sets hotel's address
        /// </summary>
        public string Address { get; set; } = "";
        /// <summary>
        /// Gets and sets hotel's phone
        /// </summary>
        public string Phone { get; set; } = "";
        /// <summary>
        /// Gets and sets description
        /// </summary>
        public string Description { get; set; } = "";
        /// <summary>
        /// Gets and sets the starting price of the hotel rooms
        /// </summary>
        public float StartingPrice { get; set; } = 0;
        /// <summary>
        /// Gets and sets the image of the hotel
        /// </summary>
        public string Image { get; set; } = "";
        /// <summary>
        /// Gets and sets the average rating 
        /// </summary>

        public float AvgRating { get; set; } = 0;
    }
}

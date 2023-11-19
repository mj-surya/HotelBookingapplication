using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Hotel
    {
        /// <summary>
        /// Gets or sets the unique identifier of the hotel
        /// </summary>
        [Key]
        public int HotelId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier associated with the hotel
        /// </summary>
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }

        /// <summary>
        /// Gets or sets the hotel name
        /// </summary>
        public string  HotelName { get; set; }

        /// <summary>
        /// Gets or sets city where hotel is located
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address of the hotel
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the hotel
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the description of the hotel
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the starting price of the hotel
        /// </summary>
        public float StartingPrice { get; set; } = 0;
    }
}

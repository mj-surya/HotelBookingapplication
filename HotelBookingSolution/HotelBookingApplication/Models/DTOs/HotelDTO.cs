using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models.DTOs
{
    public class HotelDTO
    {
        /// <summary>
        /// Gets or sets the name of the hotel.
        /// </summary>
        [Required(ErrorMessage ="Hotel name cannot be empty")]
        public string HotelName { get; set; }
        [Required(ErrorMessage = "UserId cannot be empty")]

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with the hotel.
        /// </summary>
        public string UserId { get; set; }
        [Required(ErrorMessage = "City cannot be empty")]

        /// <summary>
        /// Gets or sets the city where the hotel is located.
        /// </summary>
        public string City { get; set; }
        [Required(ErrorMessage = "Address cannot be empty")]

        /// <summary>
        /// Gets or sets the address of the hotel.
        /// </summary>
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone cannot be empty")]

        /// <summary>
        /// Gets or sets the phone number of the hotel.
        /// </summary>
        public string Phone { get; set; }
        [Required(ErrorMessage = "Description cannot be empty")]

        /// <summary>
        /// Gets or sets the description of the hotel.
        /// </summary>
        public string Description { get; set; }
    }
}

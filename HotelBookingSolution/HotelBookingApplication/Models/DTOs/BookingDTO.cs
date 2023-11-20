using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models.DTOs
{
    public class BookingDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Required(ErrorMessage ="User ID cannot be empty")]
        public String UserId { get; set; }
        /// <summary>
        /// Gets or sets the check-in date  for a reservation.
        /// </summary>
        [Required(ErrorMessage = "Check_In Date cannot be empty")]
        public string CheckIn { get; set; }

        /// <summary>
        /// Gets or sets the check-out date for a reservation.
        /// </summary>
        [Required(ErrorMessage = "check_out Date cannot be empty")]
        public string CheckOut { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the room.
        /// </summary>
        [Required(ErrorMessage ="Room ID cannot be empty")]
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets the total number of rooms for a reservation.
        /// </summary>
        [Required(ErrorMessage = "Total rooms cannot be empty")]
        public int TotalRoom { get; set; }

    }
}

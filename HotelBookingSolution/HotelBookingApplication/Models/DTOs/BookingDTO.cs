using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models.DTOs
{
    public class BookingDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// Gets or sets the check-in date  for a reservation.
        /// </summary>
        public string CheckIn { get; set; }

        /// <summary>
        /// Gets or sets the check-out date for a reservation.
        /// </summary>
        public string CheckOut { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the room.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets the total number of rooms for a reservation.
        /// </summary>
        public int TotalRoom { get; set; }

    }
}

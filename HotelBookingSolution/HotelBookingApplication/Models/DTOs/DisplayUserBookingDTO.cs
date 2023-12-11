using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models.DTOs
{
    public class DisplayUserBookingDTO
    {
        /// <summary>
        /// Gets and sets Booking ID
        /// </summary>
        public int BookingId { get; set; } = 0;
        /// <summary>
        /// Gets and sets userID
        /// </summary>
        public string UserId { get; set; } = "";
        /// <summary>
        /// Gets and sets booking date
        /// </summary>
        public string BookingDate { get; set; } = "";
        /// <summary>
        /// Gets and sets chechIn date
        /// </summary>
        public string CheckIn { get; set; } = "";
        /// <summary>
        /// Gets and sets checkOut date
        /// </summary>
        public string CheckOut { get; set; } = "";
        /// <summary>
        /// Gets and sets roomId
        /// </summary>
        public int RoomId { get; set; } = 0;
        /// <summary>
        /// Gets and sets booking status
        /// </summary>
        public string Status { get; set; } = "";
        /// <summary>
        /// Gets and sets total rooms booked
        /// </summary>
        public int TotalRoom { get; set; } = 0;
        /// <summary>
        /// Gets and sets the total price
        /// </summary>
        public float Price { get; set; } = 0;
        /// <summary>
        /// Gets and sets payment method
        /// </summary>
        public string Payment { get; set; } = "";
        /// <summary>
        /// Gets and sets the hotel name
        /// </summary>
        public string? HotelName { get; set; } = "";
        /// <summary>
        /// Gets and sets the room type
        /// </summary>
        public string RoomType { get; set; } = "";
    }
}

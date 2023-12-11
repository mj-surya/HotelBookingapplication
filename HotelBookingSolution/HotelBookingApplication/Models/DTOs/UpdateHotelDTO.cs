namespace HotelBookingApplication.Models.DTOs
{
    public class UpdateHotelDTO
    {
        /// <summary>
        /// Gets and sets hotel name
        /// </summary>
        public string HotelName { get; set; } = "";
        /// <summary>
        /// Gets and sets hotel's city
        /// </summary>
        public string City { get; set; } = "";
        /// <summary>
        /// Gets and sets the hotel's address
        /// </summary>
        public string  Address { get; set; } = "";
        /// <summary>
        /// Gets and sets hotel's phone
        /// </summary>
        public string Phone { get; set; } = "";
        /// <summary>
        /// Gets and sets description
        /// </summary>
        public string Description { get; set; } = "";
    }
}

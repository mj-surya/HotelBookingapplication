namespace HotelBookingApplication.Models.DTOs
{
    public class UpdateUserDto
    {
        /// <summary>
        /// Gets and sets user's name
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// Gets and sets user's address
        /// </summary>
        public string Address { get; set; } = "";
        /// <summary>
        /// Gets and sets user's phone
        /// </summary>
        public string Phone { get; set; } = "";
    }
}

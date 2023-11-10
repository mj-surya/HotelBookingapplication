using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models
{
    public class User
    {
        /// <summary>
        /// Gets and sets Email as primary key
        /// </summary>
        [Key]
        public string Email { get; set; }
        /// <summary>
        /// Gets and sets password
        /// </summary>
        public byte[] Password { get; set; }
        /// <summary>
        /// Gets and sets name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets and sets phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Gets and sets address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Gets and sets role
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// Gets and sets key
        /// </summary>
        public byte[] Key { get; set; }
    }
}

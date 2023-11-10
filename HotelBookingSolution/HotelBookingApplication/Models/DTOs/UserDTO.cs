using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models.DTOs
{
    public class UserDTO
    { 
        /// <summary>
        /// Gets Email id as primary key and required field
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; }
        /// <summary>
        /// Gets password required field
        /// </summary>
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }

        /// <summary>
        /// Token should be generated
        /// </summary>
        public string? Token { get; set; }
        /// <summary>
        /// Roles of the user(Admin/User)
        /// </summary>
        public string? Role { get; set; }
    }
}
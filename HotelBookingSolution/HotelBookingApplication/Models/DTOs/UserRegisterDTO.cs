using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models.DTOs
{
    public class UserRegisterDTO : UserDTO
    {
        /// <summary>
        /// Gets retype password for verification as required field
        /// </summary>
        [Required(ErrorMessage = "Re type password cannot be empty")]
        [Compare("Password", ErrorMessage = "Password and retype password do not match")]
        public string ReTypePassword { get; set; }
        /// <summary>
        /// Gets name as required field
        /// </summary>
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        /// <summary>
        /// Gets Phone as required field
        /// </summary>
        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }
        /// <summary>
        /// Gets address as required field
        /// </summary>
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

    }
}

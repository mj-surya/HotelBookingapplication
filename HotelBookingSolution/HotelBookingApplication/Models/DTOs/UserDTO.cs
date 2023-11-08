using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models.DTOs
{
    public class UserDTO
    { 
        [Key]
        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; }
        public string Role { get; set; }
        public string? Token { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models.DTOs
{
    public class HotelDTO
    {
        [Required(ErrorMessage ="Hotel name cannot be empty")]
        public string HotelName { get; set; }
        [Required(ErrorMessage = "City cannot be empty")]
        public string City { get; set; }
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Images cannot be empty")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Amenities cannot be empty")]
        public string Amenities { get; set; }
    }
}

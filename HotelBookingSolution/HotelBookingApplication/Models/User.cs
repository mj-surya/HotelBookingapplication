using System.ComponentModel.DataAnnotations;

namespace HotelBookingApplication.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public byte[] Key { get; set; }
    }
}

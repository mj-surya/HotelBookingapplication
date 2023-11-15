using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApplication.Models
{
    public class Image
    {
        [Key]
        public string ImageId { get; set; }
        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        public string Picture { get; set; }
    }
}
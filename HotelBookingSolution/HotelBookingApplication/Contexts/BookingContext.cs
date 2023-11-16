using HotelBookingApplication.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelBookingApplication.Contexts
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions options) : base(options)
        {

        }
        /// <summary>
        /// Creates User table in database
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Creates Hotel table in database
        /// </summary>
        public DbSet<Hotel> Hotels { get; set; }
        /// <summary>
        /// Creates Room table in database
        /// </summary>
        public DbSet<Room> Rooms { get; set; }
        /// <summary>
        /// Creates Amenity table in database
        /// </summary>
        public DbSet<Amenity> Amenities { get; set; }
        /// <summary>
        /// Creates Review table in database
        /// </summary>
        public DbSet<Review> Reviews { get; set; }
    }
}

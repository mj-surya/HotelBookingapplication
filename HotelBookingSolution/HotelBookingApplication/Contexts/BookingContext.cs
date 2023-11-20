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
       
        /// Creates Room Amenity table in database
        /// </summary>
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        /// <summary>
        /// Creates Review table in database
        /// </summary>
        public DbSet<Review> Reviews { get; set; }
        /// <summary>
        /// Creates the Booking in the database
        /// </summary>
        public DbSet<Booking> Bookings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure the relationship between Hotels and Reviews
            modelBuilder.Entity<Review>()
            .HasOne(e => e.user)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Booking>()
           .HasOne(e => e.room)
           .WithMany()
           .OnDelete(DeleteBehavior.NoAction);
        }
    }
 }

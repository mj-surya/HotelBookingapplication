using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Interfaces
{
    public interface IBookingService
    {
        public BookingDTO AddBookingDetails(BookingDTO bookingDTO);
        public Booking UpdateBookingStatus(int bookingId, string status);
        public List<Booking> GetUserBooking(string userId);

        public List<Booking> GetBooking(int hotelId);
    }
}

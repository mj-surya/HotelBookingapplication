using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Repositories;

namespace HotelBookingApplication.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<int, Booking> _bookingRepository;
        private readonly IRepository<int, Room> _roomRepository;
        

        public BookingService(IRepository<int, Booking> bookingRepository,IRepository<int,Room> roomRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }
        public BookingDTO AddBookingDetails(BookingDTO bookingDTO)
        {
            int roomId = bookingDTO.RoomId;
            var room = _roomRepository.GetById(roomId);
            float amount = (bookingDTO.TotalRoom * room.Price);
            DateTime dateTime = DateTime.Now;
            Booking booking = new Booking()
            {
                UserId = bookingDTO.UserId,
                CheckIn = bookingDTO.CheckIn,
                CheckOut = bookingDTO.CheckOut,
                RoomId = bookingDTO.RoomId,
                TotalRoom = bookingDTO.TotalRoom,
                Status = "Booked",
                BookingDate = dateTime.ToString(),
                Price = amount
          
            };
            var result = _bookingRepository.Add(booking);
            if(result != null)
            {
                return bookingDTO;
            }
            return null;
        }
        public List<Booking> GetBooking(int hotelId)
        {
            var bookings = (from Booking in _bookingRepository.GetAll()
                            join room in _roomRepository.GetAll() on Booking.RoomId equals room.RoomId
                            where room.HotelId == hotelId
                            select new Booking
                            {
                                BookingId = Booking.BookingId,
                                BookingDate = Booking.BookingDate,
                                CheckIn = Booking.CheckIn,
                                CheckOut = Booking.CheckOut,
                                RoomId = Booking.RoomId,
                                Status = Booking.Status,
                                TotalRoom = Booking.TotalRoom,
                                Price = Booking.Price ,
                                UserId = Booking.UserId
                            })
                    .ToList();
            if(bookings.Count > 0)
            {
                return bookings;
            }
            return null;
        }

        public List<Booking> GetUserBooking(string userId)
        {
            var user = _bookingRepository.GetAll().Where(u => u.UserId == userId).ToList();
            if(user != null)
            {
                return user;
            }
            throw new NoBookingsAvailableException();
        }

        public Booking UpdateBookingStatus(int bookingId, string status)
        {
            var user = _bookingRepository.GetById(bookingId);
            if(user != null)
            {
                user.Status = status;
                var result = _bookingRepository.Update(user);
                return user;
            }
            return null;
        }
    }
}

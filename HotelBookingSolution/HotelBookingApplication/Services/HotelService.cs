using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<int, Hotel> _hotelRepository;
        private readonly IRepository<int, Review> _reviewRepository;
        private readonly IRepository<int, Room> _roomRepository;

        public HotelService(IRepository<int, Hotel> repository, IRepository<int, Review> reviewRepository, IRepository<int, Room> roomRepository)
        {
            _hotelRepository = repository;
            _reviewRepository = reviewRepository;
            _roomRepository = roomRepository;
        }

        public HotelDTO AddHotel(HotelDTO hotelDTO)
        {
            Hotel hotel = new Hotel()
            {
                HotelName = hotelDTO.HotelName,
                City = hotelDTO.City,
                Address = hotelDTO.Address,
                UserId= hotelDTO.UserId,
                Phone = hotelDTO.Phone,
                Description = hotelDTO.Description,
            };
            var result = _hotelRepository.Add(hotel);
             
            if(result != null)
            {
                return hotelDTO;
            }
            return null;
        }

        public List<Hotel> GetHotels(string city)
        {

            var hotels = _hotelRepository.GetAll().Where(c => c.Address.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList(); 
            foreach (var a in hotels)
            {
                int id = a.HotelId;
                if(_roomRepository.GetAll().Where(r => r.HotelId == id).ToList().Count != 0)
                {
                    float price = (from Room in _roomRepository.GetAll()
                                   where Room.HotelId == id
                                   select (Room.Price))
                    .Min();
                    a.StartingPrice = price;
                }
                
            }
            if (hotels != null)
            {
                return hotels;
            }
            throw new NoHotelsAvailableException();
        }

        public bool RemoveHotel(int id)
        {

            var result = _hotelRepository.Delete(id);
            if(result!= null)
            {
                return true;
            }
            return false;
        }

        public HotelDTO UpdateHotel(int id,HotelDTO hotelDTO)
        { 
            var hotel = _hotelRepository.GetById(id);
            if(hotel != null)
            {
                hotel.Phone = hotelDTO.Phone;
                hotel.Address = hotelDTO.Address;
                hotel.HotelName = hotelDTO.HotelName;
                hotel.City = hotelDTO.City;
                hotel.Description = hotelDTO.Description;
                var result = _hotelRepository.Update(hotel);
                return hotelDTO;
            }
            return null;
        }
    }
}

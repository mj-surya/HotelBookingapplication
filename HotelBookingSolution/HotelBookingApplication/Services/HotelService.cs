using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<int, Hotel> _hotelRepository;
        
        public HotelService(IRepository<int, Hotel> repository)
        {
            _hotelRepository = repository;
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

        public List<Hotel> GetHotels()
        {
            var hotels = _hotelRepository.GetAll();
            if(hotels != null)
            {
                return hotels.ToList();
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

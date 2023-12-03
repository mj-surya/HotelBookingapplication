using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetHotels(string city);
        HotelDTO AddHotel(HotelDTO hotelDTO);
        UpdateHotelDTO UpdateHotel(int id, UpdateHotelDTO hotelDTO);

        Hotel GetByUserId(string id);
        bool RemoveHotel(int id);
    }
}

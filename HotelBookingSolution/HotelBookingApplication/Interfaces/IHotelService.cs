using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Interfaces
{
    public interface IHotelService
    {
        List<HotelDisplayDTO> GetHotels(string city);
        HotelDTO AddHotel(HotelDTO hotelDTO);
        HotelDTO UpdateHotel(int id, HotelDTO hotelDTO);
        bool RemoveHotel(int id);
    }
}

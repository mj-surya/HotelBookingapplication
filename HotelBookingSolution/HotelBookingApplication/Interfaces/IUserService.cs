using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
    }
}

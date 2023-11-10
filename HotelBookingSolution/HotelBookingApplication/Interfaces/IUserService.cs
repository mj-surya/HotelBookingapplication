using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Logging in a user
        /// </summary>
        /// <param name="userDTO">Login Credentials</param>
        /// <returns>Returns login credential with token</returns>
        UserDTO Login(UserDTO userDTO);
        /// <summary>
        /// Registers an user in the application
        /// </summary>
        /// <param name="userDTO">Registeration details</param>
        /// <returns>Returns user details</returns>
        UserRegisterDTO Register(UserRegisterDTO userDTO);
    }
}

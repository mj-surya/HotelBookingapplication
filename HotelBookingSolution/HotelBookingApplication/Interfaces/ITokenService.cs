using HotelBookingApplication.Models.DTOs;

namespace HotelBookingApplication.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Creates a token for the user
        /// </summary>
        /// <param name="user">User data</param>
        /// <returns>Returns a token</returns>
        string GetToken(UserDTO user);
    }
}

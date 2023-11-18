using System.Runtime.Serialization;

namespace HotelBookingApplication.Exceptions
{
    [Serializable]
    public class NoBookingsAvailableException : Exception
    {
        string message;
        public NoBookingsAvailableException()
        {
            message = "No bookings available to display";
        }
        public override string Message => message;
    }
}
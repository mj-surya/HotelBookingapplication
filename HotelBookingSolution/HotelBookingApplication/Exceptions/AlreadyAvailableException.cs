using System.Runtime.Serialization;
using Twilio.TwiML.Messaging;

namespace HotelBookingApplication.Exceptions
{
    [Serializable]
    internal class AlreadyAvailableException : Exception
    {
        string message;
        public AlreadyAvailableException()
        {
            message = "An hotel already exists with this user";
        }
        public override string Message => message;


    }
}
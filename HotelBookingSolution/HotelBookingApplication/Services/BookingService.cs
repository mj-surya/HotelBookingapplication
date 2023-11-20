using HotelBookingApplication.Exceptions;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Models.DTOs;
using HotelBookingApplication.Repositories;
using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace HotelBookingApplication.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<int, Booking> _bookingRepository;
        private readonly IRepository<int, Room> _roomRepository;
        private readonly IRepository<int, Hotel> _hotelRepository;
        private readonly IRepository<string, User> _userRepository;

        public BookingService(IRepository<int, Booking> bookingRepository,IRepository<int,Room> roomRepository, IRepository<int , Hotel> hotelRepository, IRepository<string, User> userRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Adds the booking details based on the provided bookingDTO
        /// </summary>
        /// <param name="bookingDTO">BookingDTO contains details of booking</param>
        /// <returns>returns the bookingDTo if the booking was succesfully added; otherwise returns a null value</returns>
        public BookingDTO AddBookingDetails(BookingDTO bookingDTO)
        {

            // Retrieve the room id based on the roomId from bookingDTO
            int roomId = bookingDTO.RoomId;
            var room = _roomRepository.GetById(roomId);
            var hotel = _hotelRepository.GetById(room.HotelId);

            //Calculate the amount for booking based on the price of the room and total number of room
            float amount = (bookingDTO.TotalRoom * room.Price);
            DateTime dateTime = DateTime.Now;

            //Create a new booking object with the details from bookingDTO
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
            //Add the new booking to the repository
            var result = _bookingRepository.Add(booking);
            var user = _userRepository.GetById(bookingDTO.UserId);
            string message = $"Dear {user.Name},\nThank you for choosing {hotel.HotelName}! Your reservation is confirmed, and we are thrilled to welcome you for your upcoming stay. Your booking reference number is {result.BookingId}. \nSafe travels!\nBest regards,\nThe {hotel.HotelName} Team\n{hotel.Phone}";
            string subject = $"Booking Confirmation - {hotel.HotelName}";
            string body = $"Dear Sir/Mam,\nThank you for choosing {hotel.HotelName}! Your reservation is confirmed, and we are thrilled to welcome you for your upcoming stay.\nBooking Details:-\nBooking ID: {result.BookingId}\nCheck-In Date: {result.CheckIn}\nCheck-Out Date: {result.CheckOut}\nRoom Type: {room.RoomType}\nTotal Price: {amount}\n\n\nWe look forward to making your stay at {hotel.HotelName} a memorable experience. Safe travels!\nBest regards,\nThe {hotel.HotelName} Team\n{hotel.Phone}";

            //Check if the booking was added successfully and return the bookingDTO
            if (result != null)
            {
                SendBookingConfirmationEmail(bookingDTO.UserId,subject,body);
                //SendBookingConfirmationSms("+91"+user.Phone,message);
                return bookingDTO;
            }
            //Returns null if booking was not added successfully
            return null;
        }
        
        /// <summary>
        /// Retrieve a list of booking object based on the unique hotel identifier
        /// </summary>
        /// <param name="hotelId">The unique identifier of a hotel</param>
        /// <returns>Returns the list of booking object for the provided hotel; Otherwise return null</returns>
        public List<Booking> GetBooking(int hotelId)
        {
            //use LINQ to join booking and room entities based on room id and filtered by hotel id and project the result into new booking
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

            //Check if the booking was found  and return the booking list; Otherwise return null
            if(bookings.Count > 0)
            {
                return bookings;
            }
            return null;
        }

        /// <summary>
        /// Retrieve the list of booking details based on the unique id of a user
        /// </summary>
        /// <param name="userId">Unique id of a user</param>
        /// <returns>Returns the list of booking object from the provided user id</returns>
        /// <exception cref="NoBookingsAvailableException">Thrown when no bookings are available for the specified user</exception>
        public List<Booking> GetUserBooking(string userId)
        {
            //Retrieve the booking details for the specified user
            var user = _bookingRepository.GetAll().Where(u => u.UserId == userId).ToList();

            //Check if the booking was found and return the booking list; Otherwise thows a NoBookingsAvailableException
            if (user != null)
            {
                return user;
            }
            throw new NoBookingsAvailableException();
        }

        /// <summary>
        /// Updates the booking status based on the bookingId and status
        /// </summary>
        /// <param name="bookingId">Unique identifier of booking to update</param>
        /// <param name="status">New status to set for the booking</param>
        /// <returns>Returns the updated booking; otherwise return null</returns>
        public Booking UpdateBookingStatus(int bookingId, string status)
        {
            //Retrieve the booking with the specified bookingId from the repository
            var booking = _bookingRepository.GetById(bookingId);
            //Check if the booking is found
            if(booking != null)
            {
                // update the status of booking
                booking.Status = status;
                //update the status in the repository
                var result = _bookingRepository.Update(booking);
                //Returns the updated booking 
                return booking;
            }
            //Returns null if the Booking was found with the specified bookingId 
            return null;
        }
        /// <summary>
        /// Sends booking confirmation Email to the user 
        /// </summary>
        /// <param name="recipientEmail">User's Email</param>
        /// <param name="subject">Subject of the email</param>
        /// <param name="body">Body text of thee email</param>
        public void SendBookingConfirmationEmail(string recipientEmail, string subject, string body)
        {

            string email = "stayquesthotel@gmail.com";
            string password = "quqzbhploasumxnd";

            // Recipient email
            string toEmail = recipientEmail;

            // Create the email message
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email);
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = body;

            // Set up SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(email, password);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            // Send the email
            smtpClient.Send(mail);

        }
        /// <summary>
        /// Sends booking confirmation SMS to the user 
        /// </summary>
        /// <param name="recipientPhoneNumber">User's phone number</param>
        /// <param name="message">SMS body text</param>
        public void SendBookingConfirmationSms(string recipientPhoneNumber, string message)
        {
            string accountSid = "ACdcb9c57053fe86e8f654fe3e2ee72b29";
            string authToken = "5db4611136c79fd4421f3cc4518c1914";
            string twilioPhoneNumber = "+19089224315";

            TwilioClient.Init(accountSid, authToken);

            var smsMessage = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber(recipientPhoneNumber)
            );
        }
    }
}
